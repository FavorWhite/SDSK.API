﻿namespace Epam.Sdesk.Model
{
    public class Attachement
    {
        public int Id { get; set; }
        public long MailId { get; set; }
        public string FileName { get; set; }
        public string FileExtention { get; set; }
        public string Path { get; set; } //where it should be saved
        public int StatusId { get; set; } //StatusId? or it may be Enum
    }
}
