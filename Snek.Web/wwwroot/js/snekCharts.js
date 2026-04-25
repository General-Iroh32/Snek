window.snekCharts = (() => {
    const palette = ["#007acc", "#4ec9b0", "#dcdcaa", "#c586c0", "#ce9178", "#569cd6"];
    const chartState = new WeakMap();

    function prepare(canvas) {
        const ratio = window.devicePixelRatio || 1;
        const width = Math.max(320, canvas.clientWidth);
        const height = Math.max(260, canvas.clientHeight);
        canvas.width = Math.round(width * ratio);
        canvas.height = Math.round(height * ratio);
        const context = canvas.getContext("2d");
        context.setTransform(ratio, 0, 0, ratio, 0, 0);
        context.clearRect(0, 0, width, height);
        return { context, width, height };
    }

    function range(values) {
        let min = Math.min(0, ...values);
        let max = Math.max(0, ...values);
        if (min === max) { min -= 1; max += 1; }
        return { min, max, span: max - min };
    }

    function drawGrid(context, width, height, margin) {
        context.strokeStyle = "#343438";
        context.lineWidth = 1;
        for (let index = 0; index <= 5; index++) {
            const y = margin + ((height - margin * 2) / 5) * index;
            context.beginPath();
            context.moveTo(margin, y);
            context.lineTo(width - margin, y);
            context.stroke();
        }
    }

    function drawLine(context, width, height, values, vertical) {
        const margin = 42;
        const availableWidth = width - margin * 2;
        const availableHeight = height - margin * 2;
        const limits = range(values);
        drawGrid(context, width, height, margin);

        const points = values.map((value, index) => {
            const progress = values.length === 1 ? .5 : index / (values.length - 1);
            const normalized = (value - limits.min) / limits.span;
            return vertical
                ? { x: margin + normalized * availableWidth, y: margin + progress * availableHeight }
                : { x: margin + progress * availableWidth, y: height - margin - normalized * availableHeight };
        });

        const gradient = context.createLinearGradient(0, margin, 0, height - margin);
        gradient.addColorStop(0, "rgba(0, 122, 204, .42)");
        gradient.addColorStop(1, "rgba(0, 122, 204, 0)");
        if (!vertical && points.length > 1) {
            context.beginPath();
            context.moveTo(points[0].x, height - margin);
            points.forEach((point) => context.lineTo(point.x, point.y));
            context.lineTo(points.at(-1).x, height - margin);
            context.closePath();
            context.fillStyle = gradient;
            context.fill();
        }

        context.beginPath();
        points.forEach((point, index) => index === 0 ? context.moveTo(point.x, point.y) : context.lineTo(point.x, point.y));
        context.strokeStyle = palette[0];
        context.lineWidth = 3;
        context.lineJoin = "round";
        context.stroke();
        points.forEach((point) => {
            context.beginPath();
            context.arc(point.x, point.y, 4, 0, Math.PI * 2);
            context.fillStyle = "#1e1e1e";
            context.fill();
            context.strokeStyle = "#9cdcfe";
            context.lineWidth = 2;
            context.stroke();
        });
    }

    function drawBars(context, width, height, values, horizontal) {
        const margin = 42;
        const limits = range(values);
        drawGrid(context, width, height, margin);
        const usableWidth = width - margin * 2;
        const usableHeight = height - margin * 2;
        const slot = (horizontal ? usableHeight : usableWidth) / values.length;
        const zero = (0 - limits.min) / limits.span;

        values.forEach((value, index) => {
            context.fillStyle = palette[index % palette.length];
            if (horizontal) {
                const start = margin + zero * usableWidth;
                const end = margin + ((value - limits.min) / limits.span) * usableWidth;
                context.fillRect(Math.min(start, end), margin + index * slot + slot * .16, Math.abs(end - start), slot * .68);
            } else {
                const baseline = height - margin - zero * usableHeight;
                const end = height - margin - ((value - limits.min) / limits.span) * usableHeight;
                context.fillRect(margin + index * slot + slot * .16, Math.min(baseline, end), slot * .68, Math.abs(end - baseline));
            }
        });
    }

    function drawPie(context, width, height, values, doughnut) {
        const magnitudes = values.map((value) => Math.abs(value));
        const total = magnitudes.reduce((sum, value) => sum + value, 0) || 1;
        const radius = Math.min(width, height) * .34;
        const centerX = width / 2;
        const centerY = height / 2;
        let angle = -Math.PI / 2;

        magnitudes.forEach((value, index) => {
            const nextAngle = angle + (value / total) * Math.PI * 2;
            context.beginPath();
            context.moveTo(centerX, centerY);
            context.arc(centerX, centerY, radius, angle, nextAngle);
            context.closePath();
            context.fillStyle = palette[index % palette.length];
            context.fill();
            context.strokeStyle = "#1e1e1e";
            context.lineWidth = 3;
            context.stroke();
            angle = nextAngle;
        });

        if (doughnut) {
            context.beginPath();
            context.arc(centerX, centerY, radius * .52, 0, Math.PI * 2);
            context.fillStyle = "#171717";
            context.fill();
        }
    }

    function render(canvas, type, rawValues) {
        const values = Array.from(rawValues, Number);
        chartState.set(canvas, { type, values });
        const { context, width, height } = prepare(canvas);
        if (!values.length) return;

        if (type === "Line") drawLine(context, width, height, values, false);
        else if (type === "VerticalLine") drawLine(context, width, height, values, true);
        else if (type === "Column") drawBars(context, width, height, values, false);
        else if (type === "Row") drawBars(context, width, height, values, true);
        else drawPie(context, width, height, values, type === "Doughnut");

        if (!canvas.dataset.resizeBound) {
            canvas.dataset.resizeBound = "true";
            new ResizeObserver(() => {
                const state = chartState.get(canvas);
                if (state) render(canvas, state.type, state.values);
            }).observe(canvas.parentElement);
        }
    }

    function downloadCanvas(canvas, filename) {
        const link = document.createElement("a");
        link.download = filename;
        link.href = canvas.toDataURL("image/png");
        link.click();
    }

    function downloadText(filename, content) {
        const link = document.createElement("a");
        link.download = filename;
        link.href = URL.createObjectURL(new Blob([content], { type: "text/plain;charset=utf-8" }));
        link.click();
        setTimeout(() => URL.revokeObjectURL(link.href), 1000);
    }

    return { render, downloadCanvas, downloadText };
})();
