using Service;
using System;
using System.ComponentModel;
using System.Threading;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FileService fileService;

        private string outputText = "";
        private string status = "";

        private Thread? fileThread;
        private DateTime lastModified;

        public string OutputText
        {
            get => outputText;
            set
            {
                outputText = value;
                OnPropertyChanged(nameof(OutputText));
            }
        }

        public string Status
        {
            get => status;
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public RelayCommand ReadFileCommand { get; }

        public MainViewModel()
        {
            fileService = new FileService();

            ReadFileCommand = new RelayCommand(ReadFile);

            if (fileService.FileExists())
            {
                lastModified = fileService.GetLastModified();
            }

            StartFileThread();
        }

        private void ReadFile()
        {
            if (fileService.FileExists())
            {
                OutputText = fileService.ReadFile();
                Status = "File read successfully.";
            }
            else
            {
                OutputText = "";
                Status = "data.txt file was not found!";
            }
        }

        private void StartFileThread()
        {
            fileThread = new Thread(CheckFile);
            fileThread.IsBackground = true;
            fileThread.Start();
        }

        private void CheckFile()
        {
            while (true)
            {
                if (fileService.FileExists())
                {
                    DateTime currentModified =
                        fileService.GetLastModified();

                    if (currentModified != lastModified)
                    {
                        lastModified = currentModified;
                    }
                }

                Thread.Sleep(500);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName)
            );
        }
    }
}