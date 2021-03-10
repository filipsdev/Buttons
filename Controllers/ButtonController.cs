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

        public ButtonController()
        {
            if(buttons.Count == 0)
            {
                for (int i = 0; i < 25; i++)
                {
                    if (random.Next(10) < 5)
                    {
                        buttons.Add(new ButtonModel(true, false));
                    }

                    else
                    {
                        buttons.Add(new ButtonModel(false, false));
                    }

                    // testing flags
                    buttons[0].IsFlagged = true;
                }
            }
        }
        
        public ActionResult Index()
        {
            return View("Button", buttons);
        }

        public ActionResult OnButtonClick(string mine)
        {
            int mineNumber = Int32.Parse(mine);
            if (!buttons[mineNumber].IsFlagged)
            {
                // only change the state of the button if the flagged property is false.
                buttons[mineNumber].State = !buttons[mineNumber].State;
            }
            
            return View("Button", buttons);
        }
        public ActionResult OnRightbuttonClick(string mine)
        {
            int buttonNumber = Int32.Parse(mine);
            buttons[buttonNumber].IsFlagged = !buttons[buttonNumber].IsFlagged;
            return View("Button", buttons);
        }

        

    }
}