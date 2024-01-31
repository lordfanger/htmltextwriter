﻿// (c) 2019 Max Feingold

using System.Collections.Generic;
using System.Linq;

namespace System.Web.UI
{
    public enum HtmlTextWriterTag
    {
        Unknown = 0,
        A = 1,
        Acronym = 2,
        Address = 3,
        Area = 4,
        B = 5,
        Base = 6,
        Basefont = 7,
        Bdo = 8,
        Bgsound = 9,
        Big = 10,
        Blockquote = 11,
        Body = 12,
        Br = 13,
        Button = 14,
        Caption = 15,
        Center = 16,
        Cite = 17,
        Code = 18,
        Col = 19,
        Colgroup = 20,
        Dd = 21,
        Del = 22,
        Dfn = 23,
        Dir = 24,
        Div = 25,
        Dl = 26,
        Dt = 27,
        Em = 28,
        Embed = 29,
        Fieldset = 30,
        Font = 31,
        Form = 32,
        Frame = 33,
        Frameset = 34,
        H1 = 35,
        H2 = 36,
        H3 = 37,
        H4 = 38,
        H5 = 39,
        H6 = 40,
        Head = 41,
        Hr = 42,
        Html = 43,
        I = 44,
        Iframe = 45,
        Img = 46,
        Input = 47,
        Ins = 48,
        Isindex = 49,
        Kbd = 50,
        Label = 51,
        Legend = 52,
        Li = 53,
        Link = 54,
        Map = 55,
        Marquee = 56,
        Menu = 57,
        Meta = 58,
        Nobr = 59,
        Noframes = 60,
        Noscript = 61,
        Object = 62,
        Ol = 63,
        Option = 64,
        P = 65,
        Param = 66,
        Pre = 67,
        Q = 68,
        Rt = 69,
        Ruby = 70,
        S = 71,
        Samp = 72,
        Script = 73,
        Select = 74,
        Small = 75,
        Span = 76,
        Strike = 77,
        Strong = 78,
        Style = 79,
        Sub = 80,
        Sup = 81,
        Table = 82,
        Tbody = 83,
        Td = 84,
        Textarea = 85,
        Tfoot = 86,
        Th = 87,
        Thead = 88,
        Title = 89,
        Tr = 90,
        Tt = 91,
        U = 92,
        Ul = 93,
        Var = 94,
        Wbr = 95,
        Xml = 96
    }

    static class HtmlTextWriterTagExtensions
    {
        static readonly Dictionary<HtmlTextWriterTag, TagMetadata> s_tags = new()
        {
            { HtmlTextWriterTag.A, new("a", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Acronym, new("acronym", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Address, new("address", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Area, new("area", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.B, new("b", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Base, new("base", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Basefont, new("basefont", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Bdo, new("bdo", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Bgsound, new("bgsound", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Big, new("big", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Blockquote, new("blockquote", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Body, new("body", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Br, new("br", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Button, new("button", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Caption, new("caption", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Center, new("center", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Cite, new("cite", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Code, new("code", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Col, new("col", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Colgroup, new("colgroup", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Dd, new("dd", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Del, new("del", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Dfn, new("dfn", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Dir, new("dir", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Div, new("div", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Dl, new("dl", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Dt, new("dt", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Em, new("em", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Embed, new("embed", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Fieldset, new("fieldset", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Font, new("font", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Form, new("form", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Frame, new("frame", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Frameset, new("frameset", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.H1, new("h1", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.H2, new("h2", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.H3, new("h3", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.H4, new("h4", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.H5, new("h5", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.H6, new("h6", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Head, new("head", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Hr, new("hr", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Html, new("html", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.I, new("i", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Iframe, new("iframe", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Img, new("img", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Input, new("input", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Ins, new("ins", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Isindex, new("isindex", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Kbd, new("kbd", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Label, new("label", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Legend, new("legend", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Li, new("li", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Link, new("link", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Map, new("map", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Marquee, new("marquee", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Menu, new("menu", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Meta, new("meta", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Nobr, new("nobr", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Noframes, new("noframes", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Noscript, new("noscript", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Object, new("object", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Ol, new("ol", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Option, new("option", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.P, new("p", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Param, new("param", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Pre, new("pre", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Q, new("q", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Rt, new("rt", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Ruby, new("ruby", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.S, new("s", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Samp, new("samp", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Script, new("script", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Select, new("select", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Small, new("small", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Span, new("span", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Strike, new("strike", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Strong, new("strong", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Style, new("style", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Sub, new("sub", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Sup, new("sup", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Table, new("table", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Tbody, new("tbody", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Td, new("td", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Textarea, new("textarea", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Tfoot, new("tfoot", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Th, new("th", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Thead, new("thead", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Title, new("title", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Tr, new("tr", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Tt, new("tt", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.U, new("u", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Ul, new("ul", BeginTagBehavior.OpenTagWithLineBreak) },
            { HtmlTextWriterTag.Var, new("var", BeginTagBehavior.OpenTag) },
            { HtmlTextWriterTag.Wbr, new("wbr", BeginTagBehavior.SelfClose) },
            { HtmlTextWriterTag.Xml, new("xml", BeginTagBehavior.OpenTagWithLineBreak) },
        };

        static readonly Dictionary<string, TagMetadata> s_names = s_tags.Values.ToDictionary(b => b.Name, b => b);
        public static bool IsKnownTag(this string name) => s_names.ContainsKey(name);
        public static TagMetadata ToMetadata(this string name) => s_names.TryGetValue(name, out TagMetadata metadata) ? metadata : new(name, BeginTagBehavior.Default);

        public static TagMetadata ToMetadata(this HtmlTextWriterTag tag) => s_tags[tag];
    }

    class TagMetadata(string name, BeginTagBehavior behavior)
    {
        public string Name { get; } = name;
        public BeginTagBehavior Behavior { get; } = behavior;
    }

    enum BeginTagBehavior
    {
        OpenTag,
        OpenTagWithLineBreak,
        SelfClose,
        Default = OpenTagWithLineBreak,
    }
}
