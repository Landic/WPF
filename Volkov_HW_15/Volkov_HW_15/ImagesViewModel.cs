using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Volkov_HW_15
{
    public class ImagesViewModel : ViewModelBase
    {
        private ImageModel image;
        private double mark;

        public ImageModel Image
        {
            get { return image; }
        }

        public double Mark
        {
            get { return mark; }
            set
            {
                if (mark == value) return;
                mark = value;
                int index = image.Ratings.FindIndex(x => x.Key == User.Example.Login);
                if (index != -1)
                {
                    image.Ratings[index] = new KeyValue(User.Example.Login, mark);
                }
                else
                {
                    image.Ratings.Add(new KeyValue(User.Example.Login, mark));
                }
                OnPropertyChanged(nameof(Mark));
            }
        }

        public string Name
        {
            get { return image.Name; }
            set
            {
                image.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Date
        {
            get { return image.Date; }
            set
            {
                image.Date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public string Author
        {
            get { return image.Author; }
            set
            {
                image.Author = value;
                OnPropertyChanged(nameof(Author));
            }
        }

        public string PathToPhoto
        {
            get
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Resources", "Images", Image.Path);
                return path;
            }
            set
            {
                image.Path = value;
                OnPropertyChanged(nameof(PathToPhoto));
            }
        }

        public string AverageRating
        {
            get
            {
                return (image.Ratings.Select(x => x.Value).Sum() / image.Ratings.Count).ToString();
            }
        }

        public string NumberOfRatings
        {
            get
            {
                return image.Ratings.Count.ToString();
            }
        }

        public ImagesViewModel(ImageModel image)
        {
            this.image = image;
            int index = image.Ratings.FindIndex(x => x.Key == User.Example.Login);
            if (index != -1)
            {
                Mark = image.Ratings[index].Value;
            }
            else
            {
                Mark = 0;
            }
        }
    }
}
