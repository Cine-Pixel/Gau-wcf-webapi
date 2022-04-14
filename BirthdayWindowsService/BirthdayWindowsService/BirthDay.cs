using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using BirthdayWindowsService.EF;
using Microsoft.Toolkit.Uwp.Notifications;

namespace BirthdayWindowsService {
    public class BirthDay {
        public readonly Timer _timer;

        public BirthDay() {
            _timer = new Timer(10000) { AutoReset = true };
            _timer.Elapsed += TimerElapsed;
        }

        public void TimerElapsed(object sender, ElapsedEventArgs e) {
            using(BirthdayDBEntities db = new BirthdayDBEntities()) {
                List<Friend> friends = db.Friends.Where(f => f.BirthDate.Value.Month == DateTime.Now.Month && f.BirthDate.Value.Day == DateTime.Now.Day).ToList();
                if(friends.Count > 0) {
                    foreach(Friend friend in friends) {
                        DateTime zeroTime = new DateTime(1, 1, 1);
                        TimeSpan span = DateTime.Now - friend.BirthDate.Value;
                        int age = (zeroTime + span).Year - 1;
                        new ToastContentBuilder()
                            .AddArgument("action", "viewConversation")
                            .AddArgument("conversationId", 9813)
                            .AddText("მეგობრის დაბადებისდღე!!!")
                            .AddText($"დღეს {friend.FirstName} {friend.LastName}-ის დაბადებისდღეა. ის {age} წლის გახდა!!!")
                            .Show();
                    }
                }
            }
        }

        public void Start() {
            _timer.Start();
        }

        public void Stop() {
            _timer.Stop();
        }
    }
}
