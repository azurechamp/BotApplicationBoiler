using System;
using System.Collections.Generic;
using System.Net;
using System.Security.AccessControl;
using System.Threading.Tasks;
using BotApplicationBoiler.Extensions;
using BotApplicationBoiler.JsonModels;
using BotApplicationBoiler.URLEndPoints;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace BotApplicationBoiler.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            //Get All Conversation Dialogs   
            var restult = await WebRequestExtension.GetConversationModelModelAsync(EndPointUrl.ConversationEndpoint);


            //Dsiplays all prompts in JSON File
            foreach (var msg  in restult)
            {
               await context.PostAsync(msg.Message);
            }

            context.Wait(MessageReceivedAsync);
        }

    
    }
}