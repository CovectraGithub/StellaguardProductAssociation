using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StellaguardProductAssociation.Models
{
    public class MessageDisplay
    {
        private bool _messageVisible = false;
        private bool _isGoodMessage = false;
        private string _message = "";

        public bool MessageVisible
        {
            get { return _messageVisible; }
            set { _messageVisible = value; }
        }

        public bool IsGoodMessage
        {
            get { return _isGoodMessage; }
            set { _isGoodMessage = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        [System.Web.Script.Serialization.ScriptIgnore]
        public string MessageJSON
        {
            get
            {
                //Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("MessageVisible",_messageVisible);
                //dict.Add("IsGoodMessage", _isGoodMessage);
                //dict.Add("Message", _message);

                System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                string jsonString = serializer.Serialize(this);

                return jsonString;
            }
        }
    }
}