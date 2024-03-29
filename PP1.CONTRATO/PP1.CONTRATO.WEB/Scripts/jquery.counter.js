﻿/*! jQuery.counter.js (jQuery Character and Word Counter plugin)
    v2.1 (c) Wilkins Fernandez
    MIT License
*/
(function (a) {
    a.fn.extend({
        counter: function (b) {
            var c = {
                type: "char",
                count: "down",
                goal: 140,
                text: true,
                msg: ""
            }, d = "",
                e = "",
                f = false,
                b = a.extend({}, c, b),
                g = {
                    init: function (b, p) {
                        var c = b.attr("id"),
                            e = c + "_count";
                        g.isLimitless();
                        b.css('float', 'inherit');
                        if (p.text === true) {
                            var nextEl = b.next('[class^="field-validation"]');
                            var lbl = a("<div/>").attr("id", c + "_counter").addClass("counter-label").html('<small><span id=' + e + ' class="label label-info" /> ' + g.setMsg() + '</small>');

                            if (nextEl.length) {
                                lbl.insertAfter(nextEl);
                            }
                            else {
                                lbl.insertAfter(b);
                            }
                        }
                        d = a("#" + e);
                        g.bind(b)
                    },
                    bind: function (a) {
                        a.bind("keypress.counter keydown.counter keyup.counter blur.counter focus.counter change.counter paste.counter", g.updateCounter);
                        a.bind("keydown.counter", g.doStopTyping);
                        a.trigger("keydown")
                    },
                    isLimitless: function () {
                        if (b.goal === "sky") {
                            b.count = "up";
                            f = true;
                            return f
                        }
                    },
                    setMsg: function () {
                        if (b.msg !== "") {
                            return b.msg
                        }
                        if (b.text === false) {
                            return ""
                        }
                        if (f) {
                            if (b.msg !== "") {
                                return b.msg
                            } else {
                                return ""
                            }
                        }
                        this.msg = null;
                        switch (b.type) {
                            case "char":
                                if (b.count === c.count && b.text) {
                                    this.msg = 'caracter(es) restantes';
                                } else if (b.count === "up" && b.text) {
                                    this.msg = 'máximo ' + b.goal + ' caracter(es)';
                                }
                                break;
                            case "word":
                                if (b.count === c.count && b.text) {
                                    this.msg = 'palavra(s) restantes';
                                } else if (b.count === "up" && b.text) {
                                    this.msg = 'máximo ' + b.goal + ' palavra(s)';
                                }
                                break;
                            default:
                        }
                        return this.msg
                    },
                    getWords: function (b) {
                        if (b !== "") {
                            return a.trim(b).replace(/\s+/g, " ").split(" ").length
                        } else {
                            return 0
                        }
                    },
                    updateCounter: function (f) {
                        var h = a(this);
                        if (e < 0 || e > b.goal) {
                            g.passedGoal(h)
                        }
                        if (b.type === c.type) {
                            if (b.count === c.count) {
                                e = b.goal - h.val().length;
                                if (e <= 0) {
                                    d.text("0")
                                } else {
                                    d.text(e)
                                }
                            } else if (b.count === "up") {
                                e = h.val().length;
                                d.text(e)
                            }
                        } else if (b.type === "word") {
                            if (b.count === c.count) {
                                e = g.getWords(h.val());
                                if (e <= b.goal) {
                                    e = b.goal - e;
                                    d.text(e)
                                } else {
                                    d.text("0")
                                }
                            } else if (b.count === "up") {
                                e = g.getWords(h.val());
                                d.text(e)
                            }
                        }
                        return
                    },
                    doStopTyping: function (a) {
                        var d = [46, 8, 9, 35, 36, 37, 38, 39, 40, 32];
                        if (g.isGoalReached(a)) {
                            if (a.keyCode !== d[0] && a.keyCode !== d[1] && a.keyCode !== d[2] && a.keyCode !== d[3] && a.keyCode !== d[4] && a.keyCode !== d[5] && a.keyCode !== d[6] && a.keyCode !== d[7] && a.keyCode !== d[8]) {
                                if (b.type === c.type) {
                                    return false
                                } else if (a.keyCode !== d[9] && a.keyCode !== d[1] && b.type != c.type) {
                                    return true
                                } else {
                                    return false
                                }
                            }
                        }
                    },
                    isGoalReached: function (a, d) {
                        if (f) {
                            return false
                        }
                        if (b.count === c.count) {
                            d = 0;
                            return e <= d ? true : false
                        } else {
                            d = b.goal;
                            return e >= d ? true : false
                        }
                    },
                    wordStrip: function (b, c) {
                        var d = c.replace(/\s+/g, " ").split(" ").length;
                        c = a.trim(c);
                        if (b <= 0 || b === d) {
                            return c
                        } else {
                            c = a.trim(c).split(" ");
                            c.splice(b, d, "");
                            return a.trim(c.join(" "))
                        }
                    },
                    passedGoal: function (a) {
                        var c = a.val();
                        if (b.type === "word") {
                            a.val(g.wordStrip(b.goal, c))
                        }
                        if (b.type === "char") {
                            a.val(c.substring(0, b.goal))
                        }
                        if (b.type === "down") {
                            d.val("0")
                        }
                        if (b.type === "up") {
                            d.val(b.goal)
                        }
                    }
                };
            return this.each(function () {
                g.init(a(this), b)
            })
        }
    })
})(jQuery)