
//wrapText(context, text, x, y, maxWidth, lineHeight);


CanvasRenderingContext2D.prototype.circle = function (x, y, w) {

    this.beginPath();
    cctx.arc(x, y, w, 0, 2 * Math.PI, false);
    this.closePath();
    return this;
}

CanvasRenderingContext2D.prototype.straightRect = function (x, y, w, h) {

    this.beginPath();
    cctx.rect(x, y, w, h);
    this.closePath();
    return this;
}

CanvasRenderingContext2D.prototype.singleRoundRect = function (x, y, w, h, r) {
    if (w < 2 * r) r = w / 2;
    if (h < 2 * r) r = h / 2;

    if (h < 0) { h = 0; }
    if (r < 0) {r = 0; }
    this.beginPath();

    this.moveTo(x + r, y);
    this.arcTo(x + w, y, x + w, y + h, r);
    this.lineTo(x + w, y + h);
    this.lineTo(x, y + h);
    this.lineTo(x, y);

    this.closePath();
}


CanvasRenderingContext2D.prototype.roundRect = function (x, y, w, h, r) {
    if (w < 2 * r) r = w / 2;
    if (h < 2 * r) r = h / 2;

    if (h < 0) { h = 0; }
    if (r < 0) { r = 0; }

    this.beginPath();
    this.moveTo(x + r, y);
    this.arcTo(x + w, y, x + w, y + h, r);
    this.arcTo(x + w, y + h, x, y + h, r);
    this.arcTo(x, y + h, x, y, r);
    this.arcTo(x, y, x + w, y, r);
    this.closePath();
    return this;
}

CanvasRenderingContext2D.prototype.roundRect2 = function (sx, sy, ex, ey, r) {
    var r2d = Math.PI / 180;
    if ((ex - sx) - (2 * r) < 0) {
        r = ((ex - sx) / 2);
    } //ensure that the radius isn't too large for x
    if ((ey - sy) - (2 * r) < 0) {
        r = ((ey - sy) / 2);
    } //ensure that the radius isn't too large for y
    this.beginPath();
    this.moveTo(sx + r, sy);
    this.lineTo(ex - r, sy);
    this.arc(ex - r, sy + r, r, r2d * 270, r2d * 360, false);
    this.lineTo(ex, ey - r);
    this.arc(ex - r, ey - r, r, r2d * 0, r2d * 90, false);
    this.lineTo(sx + r, ey);
    this.arc(sx + r, ey - r, r, r2d * 90, r2d * 180, false);
    this.lineTo(sx, sy + r);
    this.arc(sx + r, sy + r, r, r2d * 180, r2d * 270, false);
    this.closePath();
    return this;
}


function wraptextsign(context, text, x, y, maxWidth, lineHeight, posneg) {
    var words = text.trim().split(' ');
    var line = '';
    var lineN = 0;
    var testLine = ""
    var metrics;
    var testWidth = 0;
    var testWidth_old = 0;
    for (var n = 0; n < words.length; n++) {

        testLine = line;
        metrics = context.measureText(line);
        testWidth_old = metrics.width;

        testLine = line + words[n] + ' ';
        metrics = context.measureText(testLine);
        testWidth = metrics.width;

        if (testWidth > maxWidth) {


            //if (lineN == 0) {

            if (posneg == 1) {
                context.fillText(line.trim(), x, y);
            }
            if (posneg == -1) {
                context.fillText(line.trim(), x - testWidth_old, y);
            }
            //}
            line = words[n] + ' ';
            testLine = line;
            metrics = context.measureText(line);
            testWidth = metrics.width;
            y += lineHeight;

            lineN += 1;

        }
        else {
            line = testLine;
        }
    }
    //if (lineN == 0) {

    if (posneg == 1) {
        context.fillText(line.trim(), x, y);
    }
    if (posneg == -1) {
        context.fillText(line.trim(), x - testWidth, y);
    }
    //}
    //context.fillText(line, x, y);
    return lineN

}

 

function wraptext(context, text, x, y, maxWidth, lineHeight) {

    //text = "ditislangdietext";
    var words = text.trim().split(' ');
    var line = '';
    var lineN = 0;
    for (var n = 0; n < words.length; n++) {

        var testLine = line + words[n] + ' ';
        var metrics = context.measureText(testLine);
        var testWidth = metrics.width;
        if (testWidth > maxWidth) {
            //if (line != "") {
                context.fillText(line, x, y);
                line = words[n] + ' ';
                y += lineHeight;
                lineN += 1;
            //}
            //else
            //{
            //    context.fillText(testLine, x, y);
            //    line = '';
            //    y += lineHeight;
            //    lineN += 1;
            //}
        }
        else {
            line = testLine;
            //if (n == words.length - 1) {
            //    //if (testWidth > maxW) { maxW = testWidth }
            //    lineN += 1;
            //    context.fillText(line, x, y);
            //    break;
            //}
        }
    }

    if (line.trim() != "") {
        lineN += 1;
        context.fillText(line, x, y);
         
    }
    return lineN
}
 

function wraptexttest(context, text, x, y, maxWidth, lineHeight) {
    var testWidth = 0;
    var testWidthOld = 0; var maxW = 0;
    var dims = new Array(2);
    //text = "ditislangdietext";
    var words = text.trim().split(' ');
    var line = '';
    var lineN = 0;
    for (var n = 0; n < words.length; n++) {

        var testLine = line + words[n] + ' ';
        var metrics = context.measureText(testLine);
        testWidthOld = testWidth;
        var testWidth = metrics.width;
        if (testWidth > maxWidth) {
            //if (line != "") {
            if (testWidthOld > maxW) { maxW = testWidthOld }
            //context.fillText(line, x, y);
            line = words[n] + ' ';
            y += lineHeight;
            lineN += 1;
            //}
            //else {
            //    context.fillText(testLine, x, y);
            //    line = '';
            //    y += lineHeight;
            //    lineN += 1;
            //    if (testWidthOld > maxW) { maxW = testWidthOld }
            //}
        }
        else {
            line = testLine;
            //if (n == words.length - 1) {
            //    if (testWidth > maxW) { maxW = testWidth }
            //    lineN += 1;
            //    context.fillText(line, x, y);
            //    break;
            //}
        }
    }
    if (line.trim() != "") {
        lineN += 1;
        //context.fillText(line, x, y);
        var metrics = context.measureText(line);
        testWidth = metrics.width;
        if (testWidth > maxW) { maxW = testWidth }
    }
    //return lineN

    dims[0] = maxW;
    dims[1] = lineN;
    return dims;
}

function wraptextSingleLine(context, text, x, y, maxWidth) {
    var words = text.trim().split(' ');
    var line = '';
    var testWidthOld = 0;
    for (var n = 0; n < words.length; n++) {
        
        var testLine = line + words[n] + ' ';
        var metrics = context.measureText(testLine);
        var testWidth = metrics.width;
        var done = 0;
        if (testWidth > maxWidth) {
            break;
        }
        else {
            line = testLine;
            testWidthOld = testWidth;
        }
    }

    context.fillText(line, x, y);
    return testWidthOld;
    //context.fillText(line, x, y);

}

function drawTextAlongArcSimple(context, str, centerX, centerY, radius, angle) {
    var len = str.length, s;
    context.save();
    context.translate(centerX, centerY);
    context.rotate(-1 * angle / 2);
    context.rotate(-1 * (angle / len) / 2);
    for (var n = 0; n < len; n++) {
        context.rotate(angle / len);
        context.save();
        context.translate(0, -1 * radius);
        s = str[n];
        context.fillText(s, 0, 0);
        context.restore();
    }
    context.restore();
}

function drawTextAlongArc(context, str, centerX, centerY, radius, angleStart, angleEnd) {
    var len = str.length, s;
    var shift = .03;
    var needed = len * shift;
    var startNow = ((angleEnd - angleStart) - needed) / 2;
    //if (startNow < 0) startNow = 0;
    startNow -= shift;
    context.save();
    context.translate(centerX, centerY);
    context.rotate(angleStart + startNow + Math.PI / 2);
    //context.rotate(-1 * (angle / len) / 2);

    for (var n = 0; n < len; n++) {
        context.rotate(shift);
        context.save();
        context.translate(0, -1 * radius);
        s = str[n];
        context.fillText(s, 0, 0);
        context.restore();
    }
    context.restore();
}


function GetWidth() {
    var x = 0;
    if (self.innerHeight) {
        x = self.innerWidth;
    }
    else if (document.documentElement && document.documentElement.clientHeight) {
        x = document.documentElement.clientWidth;
    }
    else if (document.body) {
        x = document.body.clientWidth;
    }
    return x;
}

function GetHeight() {
    var y = 0;
    if (self.innerHeight) {
        y = self.innerHeight;
    }
    else if (document.documentElement && document.documentElement.clientHeight) {
        y = document.documentElement.clientHeight;
    }
    else if (document.body) {
        y = document.body.clientHeight;
    }
    return y;
}


function sortNumber(a, b) {
    return a - b;
}

function trim(stringToTrim) {
    return stringToTrim.replace(/^\s+|\s+$/g, "");
}
function ltrim(stringToTrim) {
    return stringToTrim.replace(/^\s+/, "");
}
function rtrim(stringToTrim) {
    return stringToTrim.replace(/\s+$/, "");
}


function sign(x) {
    return typeof x == 'number' ? x ? x < 0 ? -1 : 1 : isNaN(x) ? NaN : 0 : NaN;
}

