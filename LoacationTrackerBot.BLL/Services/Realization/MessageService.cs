using LoacationTrackerBot.BLL.Helper;
using LoacationTrackerBot.BLL.Models;
using LoacationTrackerBot.BLL.Models.ExtensionModels;
using LoacationTrackerBot.BLL.Services.Interfaces;
using LocationTrackerBot.DAL.Repositories.Interfaces;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoacationTrackerBot.BLL.Services.Realization
{
    public class MessageService : IMessageService
    {
        IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task DistributionService(JsonElement json)
        {

            json.TryGetProperty("event", out JsonElement eventType);

            if (eventType.ValueKind != JsonValueKind.Undefined && eventType.GetString() == "message")
            {

                ResponseModel responseModel = JsonConvert.DeserializeObject<ResponseModel>(json.GetRawText());
                Boolean check = responseModel.Message.Text == await _messageRepository.CheckEMEI(responseModel.Message.Text);

                if (check)
                {
                    await MessageTextSender(responseModel, await _messageRepository.GetInformationStroll(responseModel.Message.Text));
                    await MessageKeyboardSender(responseModel, ConstantHelper.Top10, responseModel.Message.Text);
                }
                else
                {
                    switch (responseModel.Message.Text)
                    {
                        case "ТОП 10 прогулянок":
                            var temp = await _messageRepository.GetTableStroll(responseModel.Message.TrackingData);
                            await MessageTableSender(responseModel, temp.Take(6).ToList());
                            await MessageTableSender(responseModel, temp.Skip(6).Take(4).ToList());
                            await MessageKeyboardSender(responseModel, ConstantHelper.Back);
                            break;
                        case "Назад":
                            await MessageTextSender(responseModel, "Введите EMEI");
                            break;
                        default:
                            await MessageTextSender(responseModel, ConstantHelper.Error);
                            break;
                    }
                }

            }
        }
        public async Task MessageTextSender(ResponseModel responseModel, String text) {

            MessageTextModel messageModel = new MessageTextModel()
            {
                Receiver = responseModel.Sender.Id,
                Type = "text",
                Text = text
            };

            RestClient client = new RestClient(ConstantHelper.ViberSendMessage);

            RestRequest request = new RestRequest()
                 .AddJsonBody(messageModel)
                 .AddHeader(ConstantHelper.ViberAuthToken, ConstantHelper.ViberAuthTokenValue);

            RestResponse result = await client.PostAsync(request);
        }
        public async Task MessageTextSender(ResponseModel responseModel, InformationModel informationModel)
        {

            MessageTextModel messageModel = new MessageTextModel()
            {
                Receiver = responseModel.Sender.Id,
                Type = "text",
                Text = $"Всего прогулок: {informationModel.CountStroll} \n Всего км пройдено: {informationModel.TotalDistStroll} \n Всего времени, мин: {informationModel.TotalTimeStroll}"
            };

            RestClient client = new RestClient(ConstantHelper.ViberSendMessage);

            RestRequest request = new RestRequest()
                 .AddJsonBody(messageModel)
                 .AddHeader(ConstantHelper.ViberAuthToken, ConstantHelper.ViberAuthTokenValue);

            RestResponse result = await client.PostAsync(request);
        }
        public async Task MessageKeyboardSender(ResponseModel responseModel, String text)
        {
            MessageKeyboardModel keyboardModel = new MessageKeyboardModel()
            {
                Receiver = responseModel.Sender.Id,
                MinApiVersion = 7,
                Keyboard = new Keyboard() { 
                    Type = "keyboard",
                    DefaultHeight = false,
                    Buttons = new List<Buttons> { 
                        new Buttons(){
                        Text = text,
                        TextSize = "regular",
                        Rows = "1",
                        Columns = "2"
                        }
                    }
                }
            };

            RestClient client = new RestClient(ConstantHelper.ViberSendMessage);
            String jsonObject = JsonConvert.SerializeObject(keyboardModel);
            RestRequest request = new RestRequest()
                 //.AddJsonBody(keyboardModel)
                 .AddStringBody(jsonObject, ContentType.Json)
                 .AddHeader(ConstantHelper.ViberAuthToken, ConstantHelper.ViberAuthTokenValue);

            RestResponse result = await client.PostAsync(request);
        }
        public async Task MessageKeyboardSender(ResponseModel responseModel, String text, String imei)
        {
            MessageKeyboardModel keyboardModel = new MessageKeyboardModel()
            {
                Receiver = responseModel.Sender.Id,
                MinApiVersion = 7,
                TrackingData = imei,
                Keyboard = new Keyboard()
                {
                    Type = "keyboard",
                    DefaultHeight = false,
                    Buttons = new List<Buttons> {
                        new Buttons(){
                        Text = text,
                        TextSize = "regular",
                        Rows = "1",
                        Columns = "2"
                        }
                    }
                }
            };

            RestClient client = new RestClient(ConstantHelper.ViberSendMessage);
            String jsonObject = JsonConvert.SerializeObject(keyboardModel);
            RestRequest request = new RestRequest()
                 //.AddJsonBody(keyboardModel)
                 .AddStringBody(jsonObject, ContentType.Json)
                 .AddHeader(ConstantHelper.ViberAuthToken, ConstantHelper.ViberAuthTokenValue);

            RestResponse result = await client.PostAsync(request);
        }
        public async Task MessageTableSender(ResponseModel responseModel, List<TableModel> tableModel)
        {
            Int32 res = 0;
            List<Buttons> buttons = ListCompletionHelper.ListCompletion();
            foreach (TableModel tableModel1 in tableModel)
            {
                ++res;
                buttons.Add(ListCompletionHelper.ConfigNewButton("Прогулянка" + res.ToString()));
                buttons.Add(ListCompletionHelper.ConfigNewButton(tableModel1.Distance));
                buttons.Add(ListCompletionHelper.ConfigNewButton(tableModel1.Minutes));
            }

            MessageTableModel messageTableModel = new MessageTableModel()
            {
                Receiver = responseModel.Sender.Id,
                MinApiVersion = 7,
                Type = "rich_media",
                RichMedia = new RichMedia { 
                    Type = "rich_media",
                    Buttons = buttons
                }
            };

            RestClient client = new RestClient(ConstantHelper.ViberSendMessage);
            String jsonObject = JsonConvert.SerializeObject(messageTableModel);

            RestRequest request = new RestRequest()
                 .AddStringBody(jsonObject, ContentType.Json)
                 //.AddJsonBody(messageTableModel)
                 .AddHeader(ConstantHelper.ViberAuthToken, ConstantHelper.ViberAuthTokenValue);
            RestResponse result = await client.PostAsync(request);
        }
    }


}
    

