using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using Formatting = Newtonsoft.Json.Formatting;

namespace Volkov_HW_15
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class GalleryViewModel : ViewModelBase
    {
        ObservableCollection<ImagesViewModel> Images { get; set; } = new ObservableCollection<ImagesViewModel>();
        private ImagesViewModel? images;
        private int position = 0, maxImages;
        private Commands? nextImage, prevImage, firstImage, lastImage;
        public ImagesViewModel? Current_Image
        {
            get { return images; }
            set
            {
                if (images != value)
                {
                    images = value;
                    OnPropertyChanged(nameof(Current_Image));
                }
            }
        }
        public int Position
        {
            get { return position; }
            set
            {
                position = value;
                Current_Image = Images[Position];
                OnPropertyChanged(nameof(Position));
            }
        }
        public int MaxImages
        {
            get { return maxImages; }
            set
            {
                maxImages = value;
                OnPropertyChanged(nameof(MaxImages));
            }
        }
        public ICommand NextImageCommand
        {
            get
            {
                if (nextImage == null) nextImage = new Commands(exec => Next(), can => CanNext());
                return nextImage;
            }
        }
        private bool CanNext() 
        { 
            return Position != MaxImages; 
        }
        private void Next()
        {
            Position++;
        }
        public ICommand PreviousImageCommand
        {
            get
            {
                if (prevImage == null) prevImage = new Commands(exec => Previous(), can => CanPrevious());
                return prevImage;
            }
        }
        private bool CanPrevious() { return Position > 0; }
        private void Previous() => Position--;
        public ICommand FirstImageCommand
        {
            get
            {
                if (firstImage == null) firstImage = new Commands(exec => First(), can => CanFirst());
                return firstImage;
            }
        }
        private bool CanFirst() { return Position != 0; }
        private void First() => Position = 0;
        public ICommand LastImageCommand
        {
            get
            {
                if (lastImage == null) lastImage = new Commands(exec => Last(), can => CanLast());
                return lastImage;
            }
        }
        private bool CanLast() { return Position != maxImages; }
        private void Last() => Position = MaxImages;
        public GalleryViewModel()
        {
            try
            {
                string jsonContent = File.ReadAllText("Images.json");
                List<ImageModel>? images = JsonConvert.DeserializeObject<List<ImageModel>>(jsonContent);
                if (images != null)
                {
                    foreach (var image in images)
                    {
                        Images.Add(new ImagesViewModel(image));
                    }
                    if (Images.Count > 0)
                    {
                        Position = 0;
                    }
                    maxImages = images.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Gallery");
            }
        }
    }
}
