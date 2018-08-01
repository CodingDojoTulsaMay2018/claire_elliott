using System;
using System.Collections.Generic;

namespace UserDashboard.Models
{
    public class ViewModel
    {
        public User User { get; set; }
        public Comment Comment { get; set; }
        public Message Message { get; set; }
        public List<Comment> CommentsList { get; set; }
        public List<Message> MessagesList { get; set; }
    }
}