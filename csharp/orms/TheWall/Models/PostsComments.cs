using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public class PostsComments
    {
        public Posts posts { get; set; } 
        public Comments comments { get; set; } 
        public Users users { get; set; }

    }
}