using ICMSBulgaria.Models;
using Parse;
using System;
using System.Collections.Generic;
using System.Text;

namespace ICMSBulgaria
{
    public static class ParseObjectManager
    {
        public static IList<News> GetTasks()
        {
            List<News> results = new List<News>();
            var query = ParseObject.GetQuery("News").OrderBy("CreatedAt");
            IEnumerable<ParseObject> tasks = query.FindAsync().GetAwaiter().GetResult();
            foreach (ParseObject task in tasks)
            {
                results.Add(new News
                {
                    ID = task.ObjectId,
                    Title = task.Get<string>("title"),
                    Content = task.Get<string>("content")
                });
            }
            return results;
        }
    }
}
