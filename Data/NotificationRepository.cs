using System;
using System.Collections.Generic;
using Dapper;

namespace DapperUowTests.Data
{
    public class NotificationRepository
    {
        private DbSession _session;

        public NotificationRepository(DbSession session)
        {
            _session = session;
        }

        public IEnumerable<NotificationModel> Get()
        {
            return _session.Connection.Query<NotificationModel>("SELECT * FROM [Notifications]", null, _session.Transaction);
        }

        public void Save(NotificationModel model)
        {
            _session.Connection.Execute("INSERT INTO [Notifications] VALUES(NEWID(), 'Title', 'URL', GETDATE())", null, _session.Transaction);
        }
    }

    public class NotificationModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }
}
