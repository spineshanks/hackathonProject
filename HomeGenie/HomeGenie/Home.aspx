<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HomeGenie.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="http://amp.azure.net/libs/amp/latest/skins/amp-default/azuremediaplayer.min.css" rel="stylesheet">
    <script src="http://amp.azure.net/libs/amp/latest/azuremediaplayer.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Playing video from Azure asset.
            <video class="vjs-tech" height="200px" width="200px" id="901e6a53-0f77-4e9c-81e8-5bd7dd8faf24_html5_api" oncontextmenu="return false;" src="http://default5568.blob.core.windows.net/asset-0a5b47bf-9cae-479f-833f-c80892c588c0/SampleVideo_1280x720_2mb.mp4?sv=2012-02-12&amp;sr=c&amp;si=e0b8df5e-c273-430a-867c-f43ce63a6458&amp;sig=Er%2FBor67s9Nigbmds9FvL7zEt46%2FPHrwiuD7FJI4dfg%3D&amp;st=2016-06-22T17%3A46%3A34Z&amp;se=2116-06-22T17%3A46%3A34Z" preload="none" autoplay=""></video>
        </div>
        <div>
            <p>Playing from azure</p>
            <video id="vid1" class="azuremediaplayer amp-default-skin" autoplay controls width="200" height="200" poster="poster.jpg" data-setup='{"nativeControlsForTouch": false}'>
                <source src="http://testmediaservicechannel-testmediaserviceazure.channel.mediaservices.windows.net/preview.isml/manifest" type="application/vnd.ms-sstr+xml" />
            </video>
        </div>
    </form>
</body>
</html>
