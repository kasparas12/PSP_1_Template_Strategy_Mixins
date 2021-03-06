﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            //var website = new NewRankerSiteMetricsFocusedEvaluatorWebsite("https://casino.com", 5, "USA", 1, "best casino", 500000);
            var website = new OldRankerTrafficFocusedEvaluatorWebsite("https://casino.com", 5, "USA", 1, "best casino", 500000);
            website.Content = @"<!DOCTYPE html><html><head><meta charset='utf-8' /<meta http-equiv='X-UA-Compatible' content='IE=edge'><title>Some casino website</title><meta name='viewport' content='width=device-width, initial-scale=1'><link rel='stylesheet' type='text/css' media='screen' href='main.css' /><script src='main.js'></script></head><body><h1>Casino</h1><p>Lorem ipsum dolor sit Casino amet consectetur adipisicing elit. Temporibus repellendus dicta, dolores voluptates assumenda suscipit possimus. Veritatis impedit blanditiis vel! Officiis, explicabo eveniet quas nemo aliquid impedit incidunt maiores soluta.Quam vero culpa ipsum iste consequuntur magni obcaecati praesentium id </p></body></html>";

            website.RecalculateSERP();
            website.CheckForPremiumStatus();

            Console.WriteLine();

            var video = new NewRankerVideo("https://www.youtube.com/watch?v=szk1wnalFRQ", "cernobylio avarija", "Praeities Atgarsiai: Černobylio avarija", 4750);
            //var video = new OldRankerVideo("https://www.youtube.com/watch?v=szk1wnalFRQ", "cernobylio avarija", "Praeities Atgarsiai: Černobylio avarija", 4750);
            video.Content = @"Pasakojimas apie Černobylį ir šalia jo avarija esantį apleista miestą Pripetę. Laidos FaceBook: https://www.facebook.com/praeitiesatg... Autoriaus FaceBook: https://www.facebook.com/andriuspl/ Instagram: https://www.instagram.com/praeities_a... Internetinė svetainė: http://praeitiesatgarsiai.lt";
            video.ToBeSuspended();
        }
    }
}
