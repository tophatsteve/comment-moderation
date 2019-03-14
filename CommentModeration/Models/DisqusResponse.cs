using System;
using System.Collections.Generic;

namespace CommentModeration.Models
{
    public class DisqusResponse
    {
        public Cursor Cursor { get; set; }
        public int Code { get; set; }
        public List<DisqusComment> Response { get; set; }
    }

    public class Cursor
    {
        public object Prev { get; set; }
        public bool HasNext { get; set; }
        public string Next { get; set; }
        public bool HasPrev { get; set; }
        public object Total { get; set; }
        public string Id { get; set; }
        public bool More { get; set; }
    }

    public class Small
    {
        public string Permalink { get; set; }
        public string Cache { get; set; }
    }

    public class Large
    {
        public string Permalink { get; set; }
        public string Cache { get; set; }
    }

    public class Avatar
    {
        public Small Small { get; set; }
        public bool IsCustom { get; set; }
        public string Permalink { get; set; }
        public string Cache { get; set; }
        public Large Large { get; set; }
    }

    public class Author
    {
        public string Username { get; set; }
        public bool IsFollowing { get; set; }
        public string Name { get; set; }
        public bool Disable3RdPartyTrackers { get; set; }
        public bool IsPowerContributor { get; set; }
        public DateTime JoinedAt { get; set; }
        public string About { get; set; }
        public bool IsFollowedBy { get; set; }
        public string ProfileUrl { get; set; }
        public string Url { get; set; }
        public string Location { get; set; }
        public bool IsPrivate { get; set; }
        public string SignedUrl { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsAnonymous { get; set; }
        public string Id { get; set; }
        public Avatar Avatar { get; set; }
    }

    public class DisqusComment
    {
        public DateTime EditableUntil { get; set; }
        public int Dislikes { get; set; }
        public int NumReports { get; set; }
        public int Likes { get; set; }
        public string Message { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Author Author { get; set; }
        public List<object> Media { get; set; }
        public int UserScore { get; set; }
        public bool IsSpam { get; set; }
        public bool IsDeletedByAuthor { get; set; }
        public bool IsHighlighted { get; set; }
        public long? Parent { get; set; }
        public bool IsApproved { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsFlagged { get; set; }
        public string Raw_Message { get; set; }
        public bool CanVote { get; set; }
        public string Thread { get; set; }
        public string Forum { get; set; }
        public int Points { get; set; }
        public List<object> ModerationLabels { get; set; }
        public bool IsEdited { get; set; }
        public bool Sb { get; set; }
    }
}
