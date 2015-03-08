﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using Ecodistrict.Messaging;

namespace TestConsole
{  
    class Program
    {

        static void InputSpecificationTest()
        {
            try
            {
                InputSpecification inputSpec = new InputSpecification();
                inputSpec.Add("name", new Text(label: "Parent name"));
                inputSpec.Add("age", new Number(label: "Parent age"));
                List aList = new List("Children");
                aList.Add("name", new Text(label: "Child name"));
                aList.Add("age", new Number(label: "Child age"));
                inputSpec.Add("child", aList);

                Newtonsoft.Json.JsonSerializerSettings settings = new Newtonsoft.Json.JsonSerializerSettings();
                settings.Formatting = Newtonsoft.Json.Formatting.Indented;
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(inputSpec, typeof(InputSpecification), settings));
                Console.WriteLine("");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } 
        }

        static void IMessageTest()
        {
            try
            {
                string smessage = "{\"method\":\"getModels\",\"type\":\"request\"}";
                //IMessage message = (IMessage)Newtonsoft.Json.JsonConvert.DeserializeObject(smessage, typeof(IMessage));

                object message = MessageGlobals.ParseJsonMessage(smessage);

                Type type = message.GetType();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            //InputSpecificationTest();
            IMessageTest();
                       
        }
    }
}
