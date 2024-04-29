using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace OurGame2k.Models
{
    public class User
    {

        private string _name = String.Empty;
        private string _password = String.Empty;

        public User(string name, string password)
        {
            _name = name;
            _password = password;
        }

        public string Name { get => _name; set => SetField(ref _name, value); }
        public string Password { get => _password; set => SetField(ref _password, value); }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public void Save()
        {
            try
            {
                File.AppendAllLines("C:\\db\\db.txt", [JsonSerializer.Serialize(this)]);
            }
            catch { }
        }

        public static User GetFromDB(string name, string password)
        {

            StreamReader streamReader;
            string data;
            try
            {
                streamReader = new StreamReader("C:\\db\\db.txt");
                data = streamReader.ReadLine();
                while (data != null)
                {
                    User user = JsonSerializer.Deserialize<User>(data);
                    if (user != null && user.Password.Equals(password) && user.Name.Equals(name))
                    {
                        return user;
                    }
                    data = streamReader.ReadLine();
                }
            }
            catch { }


            return null;
        }
    }
}