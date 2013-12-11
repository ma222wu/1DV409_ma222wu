using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab1_1DV409.Models;

namespace Lab1_1DV409.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            SecretNumber game = new SecretNumber();

            return View(game);
        }

        [HttpPost]
        public ActionResult Index(SecretNumber game)
        {


            if (Session.IsNewSession)
            {
                if (Response.Cookies["SessId"] != null)
                {
                    Response.Cookies.Remove("SessId");
                    game.SessionExpired = true;
                }
                else
                {
                    Response.Cookies.Add(new HttpCookie("SessId", Session.SessionID));
                }
            }

            if (Session.Contents["Game"] != null)
            {
                int number = game.Guess;
                game = (SecretNumber)Session.Contents["Game"];
                game.Guess = number;
            }
            else
            {
                Session.Add("Game", game);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    

                    if (game.LastGuessedNumber.Outcome == Outcome.NoMoreGuesses || game.LastGuessedNumber.Outcome == Outcome.Right)
                    {
                        game = new SecretNumber();
                        Session.Add("Game", game);
                    }
                    else
                    {
                        game.MakeGuess(game.Guess);
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError(String.Empty, e.Message);
                }
            }

            return View(game);
        }

    }
}
