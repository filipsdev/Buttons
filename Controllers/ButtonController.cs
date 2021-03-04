using Buttons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Buttons.Controllers
{
    public class ButtonController : Controller
    {

        static List<ButtonModel> buttons = new List<ButtonModel>();
        Random random = new Random();
        // GET: Button
        public ActionResult Index()
        {
            
            for(int i=0; i<25; i++)
            {
                if (random.Next(10) > 5)
                    buttons.Add(new ButtonModel(true));
                else
                    buttons.Add(new ButtonModel(false));
            }
            
            return View("Index", buttons);
        }

        public ActionResult HandleButtonClick(string mine)
        {
            int buttonNumber = Int32.Parse(mine);
            buttons[buttonNumber].State = !buttons[buttonNumber].State;
            return View("Index", buttons);
        }
    }
}