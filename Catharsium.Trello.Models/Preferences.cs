namespace Catharsium.Trello.Models
{
    public class Preferences
    {
        //      		"permissionLevel": "private",
        public bool HideVotes { get; set; }

        //"voting": "disabled",
        //"comments": "members",
        //"invitations": "members",
        //"selfJoin": false,
        //"cardCovers": true,
        //"isTemplate": false,
        //"cardAging": "regular",
        //"calendarFeedEnabled": false,
        //"background": "5cfb3947187e870c7b827662",
        //"backgroundImage": "https://trello-backgrounds.s3.amazonaws.com/SharedBackground/2560x1920/629af48373b475321108989031363e32/photo-1559713042-410cc4949891",
        //"backgroundImageScaled": [
        //	{
        //		"width": 133,
        //		"height": 100,
        //		"url": "https://trello-backgrounds.s3.amazonaws.com/SharedBackground/133x100/044e0b07affdae0d18833c9af2dfbda1/photo-1559713042-410cc4949891.jpg"
        //	},
        //	{
        //		"width": 256,
        //		"height": 192,
        //		"url": "https://trello-backgrounds.s3.amazonaws.com/SharedBackground/256x192/044e0b07affdae0d18833c9af2dfbda1/photo-1559713042-410cc4949891.jpg"
        //	},
        //	{
        //		"width": 480,
        //		"height": 360,
        //		"url": "https://trello-backgrounds.s3.amazonaws.com/SharedBackground/480x360/044e0b07affdae0d18833c9af2dfbda1/photo-1559713042-410cc4949891.jpg"
        //	},
        //	{
        //		"width": 960,
        //		"height": 720,
        //		"url": "https://trello-backgrounds.s3.amazonaws.com/SharedBackground/960x720/044e0b07affdae0d18833c9af2dfbda1/photo-1559713042-410cc4949891.jpg"
        //	},
        //	{
        //		"width": 1024,
        //		"height": 768,
        //		"url": "https://trello-backgrounds.s3.amazonaws.com/SharedBackground/1024x768/044e0b07affdae0d18833c9af2dfbda1/photo-1559713042-410cc4949891.jpg"
        //	},
        //	{
        //		"width": 2048,
        //		"height": 1536,
        //		"url": "https://trello-backgrounds.s3.amazonaws.com/SharedBackground/2048x1536/044e0b07affdae0d18833c9af2dfbda1/photo-1559713042-410cc4949891.jpg"
        //	},
        //	{
        //		"width": 1280,
        //		"height": 960,
        //		"url": "https://trello-backgrounds.s3.amazonaws.com/SharedBackground/1280x960/044e0b07affdae0d18833c9af2dfbda1/photo-1559713042-410cc4949891.jpg"
        //	},
        //	{
        //		"width": 1920,
        //		"height": 1440,
        //		"url": "https://trello-backgrounds.s3.amazonaws.com/SharedBackground/1920x1440/044e0b07affdae0d18833c9af2dfbda1/photo-1559713042-410cc4949891.jpg"
        //	},
        //	{
        //		"width": 2133,
        //		"height": 1600,
        //		"url": "https://trello-backgrounds.s3.amazonaws.com/SharedBackground/2133x1600/044e0b07affdae0d18833c9af2dfbda1/photo-1559713042-410cc4949891.jpg"
        //	},
        //	{
        //		"width": 2560,
        //		"height": 1920,
        //		"url": "https://trello-backgrounds.s3.amazonaws.com/SharedBackground/2560x1920/629af48373b475321108989031363e32/photo-1559713042-410cc4949891"
        //	}
        //],
        public bool BackgroundTile { get; set; }
        public string BackgroundBrightness { get; set; }
        public string BackgroundBottomColor { get; set; }
        public string BackgroundTopColor { get; set; }
        public bool CanBePublic { get; set; }
        public bool CanBeEnterprise { get; set; }
        public bool CanBeOrg { get; set; }
        public bool CanBePrivate { get; set; }
        public bool CanInvite { get; set; }
    }
}