using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace SimpleImageSorting
{
    class Pic
    {
        public String Name { get; private set; }
        public String PathAndName { get; private set; }
        public String Date { get; private set; }

        public Pic(FileInfo fileInfo)
        {
            Name = fileInfo.Name;
            PathAndName = fileInfo.FullName;
            Date = getDate(fileInfo);
        }

        private string getDate(FileInfo f)
        {
            using (FileStream fs = new FileStream(f.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                BitmapSource img = BitmapFrame.Create(fs);
                BitmapMetadata md = (BitmapMetadata)img.Metadata;
                char[] dateAsChar = md.DateTaken.ToCharArray();
                char[] formattedDateAsChar = { dateAsChar[6], dateAsChar[7], dateAsChar[8], dateAsChar[9], '-', dateAsChar[3], dateAsChar[4], '-', dateAsChar[0], dateAsChar[1], '_', dateAsChar[11], dateAsChar[12], '-', dateAsChar[14], dateAsChar[15], '-', dateAsChar[17], dateAsChar[18] };
                return new string(formattedDateAsChar);
            }
        }
    }
}
