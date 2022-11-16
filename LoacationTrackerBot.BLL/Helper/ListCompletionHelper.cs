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
                    Text = "Название",
                    ActionType = "none",
                    BgColor = "#778899"
                },
                new Buttons()
                {
                    Columns = "2",
                    Rows = "1",
                    Text = "Километров",
                    ActionType = "none",
                    BgColor = "#778899",
                    TextSize = "small"
                },
                new Buttons()
                {

                    Columns = "2",
                    Rows = "1",
                    Text = "Минут",
                    ActionType = "none",
                    BgColor = "#778899"
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
                Text = text,
                ActionType = "none",
                BgColor = "#DCDCDC",
                TextSize = "small"
            };
        }

    }
}
