(function (t) {
    function e(e) {
        for (var o, c, a = e[0], u = e[1], s = e[2], l = 0, d = []; l < a.length; l++) (c = a[l]), Object.prototype.hasOwnProperty.call(i, c) && i[c] && d.push(i[c][0]), (i[c] = 0);
        for (o in u) Object.prototype.hasOwnProperty.call(u, o) && (t[o] = u[o]);
        f && f(e);
        while (d.length) d.shift()();
        return r.push.apply(r, s || []), n();
    }
    function n() {
        for (var t, e = 0; e < r.length; e++) {
            for (var n = r[e], o = !0, a = 1; a < n.length; a++) {
                var u = n[a];
                0 !== i[u] && (o = !1);
            }
            o && (r.splice(e--, 1), (t = c((c.s = n[0]))));
        }
        return t;
    }
    var o = {},
        i = { app: 0 },
        r = [];
    function c(e) {
        if (o[e]) return o[e].exports;
        var n = (o[e] = { i: e, l: !1, exports: {} });
        return t[e].call(n.exports, n, n.exports, c), (n.l = !0), n.exports;
    }
    (c.m = t),
        (c.c = o),
        (c.d = function (t, e, n) {
            c.o(t, e) || Object.defineProperty(t, e, { enumerable: !0, get: n });
        }),
        (c.r = function (t) {
            "undefined" !== typeof Symbol && Symbol.toStringTag && Object.defineProperty(t, Symbol.toStringTag, { value: "Module" }), Object.defineProperty(t, "__esModule", { value: !0 });
        }),
        (c.t = function (t, e) {
            if ((1 & e && (t = c(t)), 8 & e)) return t;
            if (4 & e && "object" === typeof t && t && t.__esModule) return t;
            var n = Object.create(null);
            if ((c.r(n), Object.defineProperty(n, "default", { enumerable: !0, value: t }), 2 & e && "string" != typeof t))
                for (var o in t)
                    c.d(
                        n,
                        o,
                        function (e) {
                            return t[e];
                        }.bind(null, o)
                    );
            return n;
        }),
        (c.n = function (t) {
            var e =
                t && t.__esModule
                    ? function () {
                          return t["default"];
                      }
                    : function () {
                          return t;
                      };
            return c.d(e, "a", e), e;
        }),
        (c.o = function (t, e) {
            return Object.prototype.hasOwnProperty.call(t, e);
        }),
        (c.p = "");
    var a = (window["webpackJsonp"] = window["webpackJsonp"] || []),
        u = a.push.bind(a);
    (a.push = e), (a = a.slice());
    for (var s = 0; s < a.length; s++) e(a[s]);
    var f = u;
    r.push([0, "chunk-vendors"]), n();
})({
    0: function (t, e, n) {
        t.exports = n("56d7");
    },
    "40b7": function (t, e, n) {},
    "513b": function (t, e, n) {},
    "56d7": function (t, e, n) {
        "use strict";
        n.r(e);
        n("e260"), n("e6cf"), n("cca6"), n("a79d");
        var o = n("7a23"),
            i = { class: "notification-container" };
        function r(t, e, n, r, c, a) {
            var u = Object(o["q"])("Notification");
            return (
                Object(o["m"])(),
                Object(o["g"])("div", i, [
                    (Object(o["m"])(!0),
                    Object(o["g"])(
                        o["a"],
                        null,
                        Object(o["p"])(c.notifications, function (t) {
                            return Object(o["m"])(), Object(o["e"])(u, { key: t.id, id: t.id, type: t.type, duration: t.duration, title: t.title, message: t.message }, null, 8, ["id", "type", "duration", "title", "message"]);
                        }),
                        128
                    )),
                ])
            );
        }
        var c = function (t) {
                return Object(o["o"])("data-v-a019ed8c"), (t = t()), Object(o["n"])(), t;
            },
            a = { key: 0, class: "notification" },
            u = { class: "notification-icon" },
            s = { class: "notification-body" },
            f = { class: "body-title" },
            l = c(function () {
                return Object(o["h"])("br", null, null, -1);
            }),
            d = { class: "body-message" };
        function p(t, e, n, i, r, c) {
            var p = Object(o["q"])("font-awesome-icon");
            return (
                Object(o["m"])(),
                Object(o["e"])(
                    o["b"],
                    { name: "notification-slide", onAfterEnter: c.afterEnter, onAfterLeave: c.afterLeave, appear: "" },
                    {
                        default: Object(o["t"])(function () {
                            return [
                                r.visible
                                    ? (Object(o["m"])(),
                                      Object(o["g"])("div", a, [
                                          Object(o["h"])("div", u, [Object(o["i"])(p, { style: Object(o["l"])({ color: c.getIconColor() }), icon: c.getIcon(), class: "icon" }, null, 8, ["style", "icon"])]),
                                          Object(o["h"])("div", s, [Object(o["h"])("span", f, Object(o["r"])(t.$props.title), 1), l, Object(o["h"])("span", d, Object(o["r"])(t.$props.message), 1)]),
                                      ]))
                                    : Object(o["f"])("", !0),
                            ];
                        }),
                        _: 1,
                    },
                    8,
                    ["onAfterEnter", "onAfterLeave"]
                )
            );
        }
        n("a9e3");
        var b = n("d037"),
            v = [b["d"], b["a"], b["b"], b["c"], b["e"]],
            O = ["#5598C3", "#FFFFFF", "#3DBA39", "#FFE13A", "#CC394F"],
            y = {
                name: "Notification",
                props: { id: { type: Number, default: 0 }, type: { type: Number, default: 0 }, duration: { type: Number, default: 1e3 }, title: { type: String, default: "" }, message: { type: String, default: "" } },
                data: function () {
                    return { visible: !1, elapsed: 0 };
                },
                mounted: function () {
                    this.visible = !0;
                },
                methods: {
                    afterEnter: function () {
                        var t = this;
                        setTimeout(function () {
                            t.hide();
                        }, this.$props.duration);
                    },
                    afterLeave: function () {
                        this.$el.remove();
                    },
                    hide: function () {
                        this.visible = !1;
                    },
                    getIcon: function () {
                        return v[this.type];
                    },
                    getIconColor: function () {
                        return O[this.type];
                    },
                },
            },
            j = (n("5a82"), n("6b0d")),
            m = n.n(j);
        const h = m()(y, [
            ["render", p],
            ["__scopeId", "data-v-a019ed8c"],
        ]);
        var g = h,
            w = {
                name: "App",
                components: { Notification: g },
                data: function () {
                    return { notifications: [] };
                },
                created: function () {
                    var t = this;
                    "alt" in window &&
                        alt.on("notifications:create", function (e) {
                            t.createNotification(e), console.log("emit success");
                        });
                },
                methods: {
                    createNotification: function (t) {
                        this.notifications.push({ id: t.id, type: t.type, duration: 1e3 * t.duration, title: t.title, message: t.message });
                    },
                },
            };
        n("ebbb");
        const F = m()(w, [["render", r]]);
        var _ = F,
            N = n("ad3d"),
            A = n("e007");
        A["c"].add(b["a"], b["b"], b["c"], b["d"], b["e"]);
        var P = N["a"];
        Object(o["d"])(_).component("font-awesome-icon", P).mount("#app");
    },
    "5a82": function (t, e, n) {
        "use strict";
        n("40b7");
    },
    ebbb: function (t, e, n) {
        "use strict";
        n("513b");
    },
});
//# sourceMappingURL=app.318ca828.js.map
