using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace BirthdayWindowsService {
    class Program {
        static void Main(string[] args) {
            var exitCode = HostFactory.Run(x => {

                x.Service<BirthDay>(s => {
                    s.ConstructUsing(birthday => new BirthDay());
                    s.WhenStarted(birthday => birthday.Start());
                    s.WhenStopped(birthday => birthday.Stop());
                });

                x.RunAsLocalService();
                x.SetServiceName("Birthday service");
                x.SetDisplayName("Birthday service");
                x.SetDescription("Reports birthday of friend");
            });

            int exitCodeValue = (int)Convert.ChangeType(exitCode, exitCode.GetTypeCode());
            Environment.ExitCode = exitCodeValue;
        }
    }
}
