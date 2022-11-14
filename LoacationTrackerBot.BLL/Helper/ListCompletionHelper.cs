using LoacationTrackerBot.BLL.Models.ExtensionModels;
using System;
using System.Collections.Generic;

namespace LoacationTrackerBot.BLL.Helper
{
    public class ListCompletionHelper
    {
        public static List<Buttons> ListCompletion() {
            List<Buttons> buttons = new List<Buttons>()
            {
                new Buttons()
                {
                    Columns = "2",
                    Rows = "1",
                    Text = "Name",
                    ActionBody = "none",
                    BgColor = "#f7bb3f"
                },
                new Buttons()
                {
                    Columns = "2",
                    Rows = "1",
                    Text = "Distance",
                    ActionBody = "none",
                    BgColor = "#f7bb3f"
                },
                new Buttons()
                {

                    Columns = "2",
                    Rows = "1",
                    Text = "Minutes",
                    ActionBody = "none",
                    BgColor = "#f7bb3f"
                }
            };
            return buttons;
        }

        public static Buttons ConfigNewButton(String text) 
        {
            return new Buttons()
            {

                Columns = "2",
                Rows = "1",
                Text = "Minutes",
                ActionBody = "none",
                BgColor = "#f7bb3f"
            };
        }

    }
}
