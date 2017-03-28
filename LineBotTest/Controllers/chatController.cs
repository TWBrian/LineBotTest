using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LineBotTest.Controllers
{
    public class chatController : ApiController
    {
        // POST: api/chat
        [HttpPost]
        public HttpResponseMessage Post()
        {
            LineBot.LineBotHelper LineBotHelper = new LineBot.LineBotHelper("1506274231", "0a9f1bab0d53115afcc748174ace0f09", "2bFsHhtMs8xELuT4SMdufjw7hqSAHzd4szu7wr2KKccpsenGXPjV0QVS9XZABrbS9iqtSxJWKnZIOV3osJJQH+ej45jmx1CZuCBSFvStGtX8L2+wVtnZM+dkvvyqrI5WdlJTaLRpHBJBzt2I/SzVjgdB04t89/1O/w1cDnyilFU=");

            //Get  Post RawData
            string postData = Request.Content.ReadAsStringAsync().Result;

            //取得LineBot接收到的訊息
            var ReceivedMessage = LineBotHelper.GetReceivedMessage(postData);

            //發送訊息
            var ret = LineBotHelper.SendMessage(new List<string>() { ReceivedMessage.result[0].content.from },"你剛才說了 " + ReceivedMessage.result[0].content.text);

            //如果給200，LineBot訊息就不會重送
            return Request.CreateResponse(HttpStatusCode.OK, ret);
        }
    }
}
