using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {            
            string welcomeText = @" __      __       .__                                  __           ____   ____.__         __               .__    __________.__                             
/  \    /  \ ____ |  |   ____  ____   _____   ____   _/  |_  ____   \   \ /   /|__|_______/  |_ __ _______  |  |   \______   \  | _____  ___.__. ___________ 
\   \/\/   // __ \|  | _/ ___\/  _ \ /     \_/ __ \  \   __\/  _ \   \   Y   / |  \_  __ \   __\  |  \__  \ |  |    |     ___/  | \__  \<   |  |/ __ \_  __ \
 \        /\  ___/|  |_\  \__(  <_> )  Y Y  \  ___/   |  | (  <_> )   \     /  |  ||  | \/|  | |  |  // __ \|  |__  |    |   |  |__/ __ \\___  \  ___/|  | \/
  \__/\  /  \___  >____/\___  >____/|__|_|  /\___  >  |__|  \____/     \___/   |__||__|   |__| |____/(____  /____/  |____|   |____(____  / ____|\___  >__|   
       \/       \/          \/            \/     \/                                                       \/                           \/\/         \/       ";
            int choice = 0;
            string soundPath;            
            MediaPlayer player = new MediaPlayer();

            GetFileSourceAndPlay();

            var tfile = TagLib.File.Create(soundPath);
            string title = tfile.Tag.Title;
            string album = tfile.Tag.Album;
            string[] artist = tfile.Tag.AlbumArtists;
            TimeSpan duration = tfile.Properties.Duration;

            Console.WriteLine($"Title: {title}\nAlbum: {album}\nArtist: {artist[0]}\nDuration: {duration}");
                       
            Console.WriteLine("File: " + soundPath + Environment.NewLine);

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(welcomeText);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("(1) Play");
            Console.WriteLine("(2) Pause");
            Console.WriteLine("(3) Stop");
            Console.WriteLine("(4) Volume Up");
            Console.WriteLine("(5) Volume Down");
            Console.WriteLine("(6) Change song");
            Console.WriteLine("(7) Exit");

            while (choice != -1)
            {
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        PlaySong();
                        break;
                    case 2:
                        PauseSong();
                        break;
                    case 3:
                        StopSong();
                        break;
                    case 4:
                        VolumeUp();
                        break;
                    case 5:
                        VolumeDown();
                        break;
                    case 6:
                        GetFileSourceAndPlay();
                        break;
                    case 7:
                        Exit();
                        break;
                    default: Console.WriteLine("choice not found!");
                        break;      
                }
            }

            void PlaySong()
            {
                player.Play();
            }

            void PauseSong()
            {
                player.Pause();
            }

            void StopSong()
            {
                player.Stop();
            }

            void VolumeUp()
            {
                player.Volume += 0.2;               
            }

            void VolumeDown()
            {
                player.Volume -= 0.2;
                if (player.Volume == 0)
                {
                    player.Volume = 0.2;
                }
            }

            void Exit()
            {
                choice = -1;
            }

           void GetFileSourceAndPlay()
            {
                Console.WriteLine("Please write a song path: (C:\\Users)");
                soundPath = Console.ReadLine();
                player.Open(new Uri(soundPath, UriKind.Relative));
                player.Play();
            }
        }
    }
}
