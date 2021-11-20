using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Identity4Example.Models
{
    public class FileUploader
    {
        public int ID { get; set; }

        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<FilePath> FilePaths { get; set; }
    }


        public class File
        {
            public int FileId { get; set; }
            public string userId { get; set; }
            [StringLength(255)]
            public string FileName { get; set; }
            [StringLength(100)]
            public string ContentType { get; set; }
            public byte[] Content { get; set; }
            public FileType FileType { get; set; }
            public int FileUploaderId { get; set; }
            public virtual FileUploader FileUploader { get; set; }

        }

        public class FilePath
        {
            public int FilePathId { get; set; }
            public string userId { get; set; }
            [StringLength(255)]
            public string FileName { get; set; }
            public FileType FileType { get; set; }
            public int FileUploaderID { get; set; }
            public virtual FileUploader FileUploader { get; set; }
        }

        public enum FileType
        {
            Avatar = 1, Photo
        }

    }
