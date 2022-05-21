using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MessagesApp.Data;
using MessagesApp.Models;
using Newtonsoft.Json;

namespace MessagesApp.Services
{

    public class Json_Contact
    {
        public string? Id { get; set; }
        public string Name { get; set; }
        public string Server { get; set; }
        public string? Last { get; set; }
        public DateTime? Lastdate { get; set; }
    }

    public class Json_Message
    {
        public int? Id { get; set; }
        //[JsonProperty("id")]
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public bool Sent { get; set; }
    }

    public class AppService
    {
        private static AppService? instance = null;
        public static AppService CreateAppService()
        {
            if (instance == null)
            {
                instance = new AppService();
                return instance;
            }
            else
            {
                return instance;
            }
        }

        private static List<User> _users = new List<User>();



        //private readonly MessagesAppContext _context;
        //public AppService(MessagesAppContext context){}
        private AppService()
        {
            //_context = context;

            if (_users.Count == 0)
            {
                // add initial users
                User tester = new User();
                tester.Username = "1";
                tester.Password = "1";
                tester.Contacts = new List<Contact>();
                _users.Add(tester);

                User u1 = new User();
                u1.Username = "alice";
                u1.Password = "allice";
                u1.Contacts = new List<Contact>();
                _users.Add(u1);

                Contact chat_0_1 = new Contact();
                chat_0_1.User = u1.Username;
                chat_0_1.Nickname = "alicia";
                chat_0_1.Messages = new List<Message>();
                chat_0_1.Server = "localhost:7266"; // not good, but for now
                tester.Contacts.Add(chat_0_1);

                Message message0 = new Message();
                message0.Id = 0;
                message0.Sent = true;
                message0.Content = "hi you";
                message0.Time = DateTime.Now;
                message0.Type = "text";

                chat_0_1.Messages.Add(message0);

                User u2 = new User();
                u2.Username = "bob";
                u2.Password = "bob";
                u2.Contacts = new List<Contact>();
                _users.Add(u2);

                Contact chat_1_2 = new Contact();
                chat_1_2.User = u2.Username;
                chat_1_2.Nickname = "bobby";
                chat_1_2.Messages = new List<Message>();
                chat_1_2.Server = "localhost:7265"; // not good, but for now
                tester.Contacts.Add(chat_1_2);

                Message message_1_2 = new Message();
                message_1_2.Id = 1;
                message_1_2.Sent = true;
                message_1_2.Content = "hi";
                message_1_2.Time = DateTime.Now;
                message_1_2.Type = "text";

                chat_1_2.Messages.Add(message_1_2);

                Message message_1_2_b = new Message();
                message_1_2_b.Id = 1;
                message_1_2_b.Sent = false;
                message_1_2_b.Content = "hi to you to";
                message_1_2_b.Time = DateTime.Now;
                message_1_2_b.Type = "text";

                chat_1_2.Messages.Add(message_1_2_b);
            }
        }

        public List<Json_Contact> ApiGetContacts(string username)
        {
            List<Json_Contact> ret = new List<Json_Contact>();
            List<Contact> contacts = GetContacts(username);
            if (contacts == null) { return null; }
            foreach (Contact contact in contacts)
            {
                ret.Add(GetJsonContact(contact));
            }
            return ret;
        }

        public Json_Contact? ApiGetContact(string username, string contactName)
        {
            Contact? contact = GetContact(username, contactName);
            if (contact == null) { return null; }
            return GetJsonContact(contact);
        }

        private Json_Contact GetJsonContact(Contact contact)
        {
            Json_Contact contact_json = new Json_Contact();
            contact_json.Id = contact.User;
            contact_json.Name = contact.Nickname;
            contact_json.Server = contact.Server;

            if(contact.Messages.Count > 0)
            {
                Message message = contact.Messages.Last();
                contact_json.Last = message.Content;
                contact_json.Lastdate = message.Time;
               
            }
            return contact_json;

        }

        public List<Json_Message> ApiGetMessages(string username, string contactName)
        {
            Contact contact = GetContact(username, contactName);
            if (contact ==null) { return null; }
            List<Json_Message> ret = new List<Json_Message>();
            foreach (Message message in contact.Messages)
            {
                ret.Add(GetJsonMessage(message));
            }
            return ret;
        }

        public Json_Message ApiGetMessage(string username, string contactName, int id)
        {
            Contact contact = GetContact(username, contactName);
            if (contact == null) { return null; }
            Message message = contact.Messages.Find(x => x.Id == id);
            if (message == null) { return null; }
            return GetJsonMessage(message);
        }

        private Json_Message GetJsonMessage(Message message)
        {
            Json_Message message_json = new Json_Message();
            message_json.Id = message.Id;
            message_json.Content = message.Content;
            message_json.Created = message.Time;
            message_json.Sent = message.Sent;

            return message_json;
        }

        public Contact? GetContact(string username, string contactName)
        {
            User user = _users.Find(x => x.Username == username);
            if (user == null) { return null; }
            Contact contact = user.Contacts.Find(x => x.User == contactName);
            if (contact == null) { return null; }
            return contact;
        }

        public List<Contact> GetContacts(string username)
        {
            List<Contact> contacts = new List<Contact>();
            User u = _users.Find(x => x.Username == username);
            if (u == null) {return null;}
            foreach (Contact c in u.Contacts)
            {
                contacts.Add(c);
            }
            return contacts;
        }

        public bool ApiAddContact(string username, Json_Contact newContact)
        {
            if (newContact == null) {return false;}
            User user = _users.Find(x => x.Username == username);
            if (user == null) {return false;}
            
            Contact contact = new Contact();
            contact.User = newContact.Id;
            contact.Nickname = newContact.Name;
            contact.Server = newContact.Server;
            contact.Messages = new List<Message>();
            user.Contacts.Add(contact);
            return true;
        }

        public bool ApiEditContact(string username, string id, Json_Contact Contact)
        {
            if (Contact == null) { return false; }
            User user = _users.Find(x => x.Username == username);
            if (user == null) { return false; }
            Contact contact = user.Contacts.Find(x => x.User == id);
            if (contact == null) { return false; }
            user.Contacts.Remove(contact);
            contact.Nickname = Contact.Name;
            contact.Server = Contact.Server;
            user.Contacts.Add(contact);
            return true;
        }

        public bool ApiAddMessage(string username, string contactName, string newMessage, bool sent)
        {

            if (newMessage == null) { return false; }
            Contact contact = GetContact(username, contactName);
            if (contact == null) { return false; }

            Message message = new Message();
            if (contact.Messages.Count > 0) { message.Id = contact.Messages.Last().Id + 1; } // might be wrong!!!!!!!!
            else { message.Id = 0; }
            
            message.Content = newMessage;
            message.Sent = sent;
            message.Time = DateTime.Now;
            message.Type = "text";
            contact.Messages.Add(message);
            return true;
        }

        public bool ApiEditMessage(string username, string contactName, string newMessage, int id)
        {

            if (newMessage == null) { return false; }
            Contact contact = GetContact(username, contactName);
            if (contact == null) { return false; }

            Message message = contact.Messages.Find(x => x.Id == id);
            if (message == null) { return false; }

            contact.Messages.Remove(message);   
            message.Content = newMessage;
            contact.Messages.Add(message);
            return true;
        }

        public bool ApiDeleteContact(string username, string contactName)
        {
            User user = _users.Find(x => x.Username == username);
            if (user == null) { return false;}
            Contact c = GetContact(username, contactName);
            if (c == null) {return false;}
            return user.Contacts.Remove(c);
        }

        public bool ApiDeleteMessage(string username, string contactName, int messageId)
        {
            Contact contact = GetContact(username, contactName);
            Message message = contact.Messages.Find(x => x.Id == messageId);
            if (message == null) { return false; }
            return contact.Messages.Remove(message);
        }

        public bool ApiUpdateContact(string username, string contactName, string contactDetails)
        {
            Contact contact = GetContact(username, contactName);
            if (contact == null) { return false; }
            Json_Contact cj = JsonConvert.DeserializeObject<Json_Contact>(contactDetails);
            if (cj == null) { return false; }
            contact.Nickname = cj.Name;
            contact.Server = cj.Server;
            return true;
        }

        public bool ApiUpdateMessage(string username, string contactName,
                                     int messageId, string messageDetails)
        {
            Contact contact = GetContact(username, contactName);
            if (contact == null) { return false; }
            Message message = contact.Messages.Find(x => x.Id == messageId);
            if (message == null) { return false; }
            Json_Message mj = JsonConvert.DeserializeObject<Json_Message>(messageDetails);
            if (mj == null) { return false; }
            message.Content = mj.Content;
            message.Time = DateTime.Now; // not sure we should update this
            return true;
        }
    }
}

        //public Message GetLastMessage(Contact contact)
        //{
        //    Message message = contact.Messages.Last();
        //    if (message == null) return null;
        //    return message;
        //}

        //public string GetMessageContent(Message message) { return message.Content; }

        //public DateTime GetMessageTime(Message message) { return message.Time; }

        //public List<Message> GetMessages()
        //{
        //    List<Message> messages = new List<Message>();

        //}


        //public string GetContactUsername(Contact contact)
        //{
        //    return contact.User;
        //}

        //public string GetContactName(Contact contact)
        //{
        //    return contact.Nickname;
        //}

        //public string GetContactServer(Contact contact)
        //{
        //    if (contact.Server == null)
        //    {
        //        return "this"; ///////////////////////////////
        //    } else
        //    {
        //        return contact.Server;
        //    }
        //}
