﻿@using EPiServer
@using EPiServer.Core
@using EPiServer.Editor
@using EPiServer.Web.Mvc.Html
@using EPiServer.Web.Routing
@model $rootnamespace$.Models.Blocks.RedirectBlock
@{
    Layout = null;
}

<div>
    @if (PageEditing.PageIsInEditMode)
    {
        <span>Redirect to:@Html.PropertyFor(x => x.url)</span>
    }
</div>

