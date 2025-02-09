﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApp.Entity
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string? Text { get; set; }
        public DateTime PublishedOn { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; } = null;

        public int UserId { get; set; }
        public User User { get; set; } = null;
    }
}
