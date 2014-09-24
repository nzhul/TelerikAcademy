using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BC.Web.Models
{
    public class JoinGameModel
    {

        public JoinGameModel(string gameName)
        {
            this.Result = "You joined game " + gameName ;
        }
        public string Result { get; set; }
    }
}