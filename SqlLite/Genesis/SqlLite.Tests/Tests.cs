using NUnit.Framework;
using SqlLite.Tests.DAL;
using SqlLite.Tests.DTO;
using SqlLite.Tests.FindCriteria;
using SqlLite.Tests.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SqlLite.Tests
{
    // https://www.sqlite.org/limits.html

    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void SetupTest()
        {
            var databaseOperations =
                new DatabaseOperationsRepository(DbFile.GetConnectionString("testdb.db"));
            databaseOperations.CreateAndInitialize(DbFile.GetPath("testdb.db"), TxtFile.ReadText("RebuildDatabase.txt"));
        }

        [Test]
        public void CRUD_One_DiaryEntry_And_Fetch_Runs_Successfully()
        {
            var connectionManager = new ConnectionManager(DbFile.GetConnectionString("testdb.db"));
            var repository = new DiaryEntryRepository(connectionManager);
            var entry = new DiaryEntry
            {
                Title = "New DiaryEntry",
                DateCreated = DateTime.Parse("2017/03/12 13:12:21").Ticks
            };

            repository.InsertOne(entry);
            var insertedEntity = repository.GetOne(1);
            Assert.IsNotNull(entry);

            insertedEntity.Title = "Modified DiaryEntry";
            repository.UpdateOne(insertedEntity);

            var updatedEntity = repository.GetOne(1);
            Assert.That(updatedEntity.Title, Is.EqualTo("Modified DiaryEntry"));

            repository.DeleteOne(updatedEntity);
            
            var deletedEntity = repository.GetOne(insertedEntity.Id);
            Assert.IsNull(deletedEntity);
        }

        [Test]
        public void CRUD_One_Attachment_And_Fetch_Runs_Successfully()
        {
            var connectionManager = new ConnectionManager(DbFile.GetConnectionString("testdb.db"));
            var repository = new AttachmentRepository(connectionManager);
            var entry = new Attachment
            {
                FileName = "filename.pdf",
                Description = "New Attachment",
                Extension = "pdf"
            };

            repository.InsertOne(entry);
            var insertedEntity = repository.GetOne(1);
            Assert.IsNotNull(entry);

            insertedEntity.Description = "Modified Attachment";
            repository.UpdateOne(insertedEntity);

            var updatedEntity = repository.GetOne(1);
            Assert.That(updatedEntity.Description, Is.EqualTo("Modified Attachment"));

            repository.DeleteOne(updatedEntity);

            var deletedEntity = repository.GetOne(insertedEntity.Id);
            Assert.IsNull(deletedEntity);
        }


        [Test]
        public void CRUD_One_Hyperlink_And_Fetch_Runs_Successfully()
        {
            var connectionManager = new ConnectionManager(DbFile.GetConnectionString("testdb.db"));
            var repository = new HyperlinkRepository(connectionManager);
            var entry = new Hyperlink
            {
                Title = "New Hyperlink",
                Url = "http://www.msn.com"
            };

            repository.InsertOne(entry);
            var insertedEntity = repository.GetOne(1);
            Assert.IsNotNull(entry);

            insertedEntity.Title = "Modified Hyperlink";
            repository.UpdateOne(insertedEntity);

            var updatedEntity = repository.GetOne(1);
            Assert.That(updatedEntity.Title, Is.EqualTo("Modified Hyperlink"));

            repository.DeleteOne(updatedEntity);

            var deletedEntity = repository.GetOne(insertedEntity.Id);
            Assert.IsNull(deletedEntity);
        }

        [Test]
        public void CRUD_One_Snippet_And_Fetch_Runs_Successfully()
        {
            var connectionManager = new ConnectionManager(DbFile.GetConnectionString("testdb.db"));
            var repository = new SnippetRepository(connectionManager);
            var entry = new Snippet
            {
                Title = "New Hyperlink",
                Content = "Here is some content for you.",
                SyntaxHighlightId = 1
            };

            repository.InsertOne(entry);
            var insertedEntity = repository.GetOne(1);
            Assert.IsNotNull(entry);

            insertedEntity.Title = "Modified Snippet";
            repository.UpdateOne(insertedEntity);

            var updatedEntity = repository.GetOne(1);
            Assert.That(updatedEntity.Title, Is.EqualTo("Modified Snippet"));

            repository.DeleteOne(updatedEntity);

            var deletedEntity = repository.GetOne(insertedEntity.Id);
            Assert.IsNull(deletedEntity);
        }


        [Test]
        public void Find_DiaryEntry_By_TitlePart()
        {
            var connectionManager = new ConnectionManager(DbFile.GetConnectionString("testdb.db"));
            var diaryEntryRepository = new DiaryEntryRepository(connectionManager);

            diaryEntryRepository.InsertOne(new DiaryEntry { DateCreated = DateTime.Parse("2017/03/12 13:12:21").Ticks, Title = "Diary Entry 1" });
            diaryEntryRepository.InsertOne(new DiaryEntry { DateCreated = DateTime.Parse("2017/03/15 08:01:59").Ticks, Title = "Diary Entry 2" });

            IEnumerable<DiaryEntry> foundEntries = diaryEntryRepository.FindByTitle("Entry 1");

            Assert.That(foundEntries.Count(), Is.EqualTo(1));
        }

        [Test]
        public void Find_DiaryEntry_By_FindCriteria_Between_2_Dates()
        {
            var connectionManager = new ConnectionManager(DbFile.GetConnectionString("testdb.db"));
            var diaryEntryRepository = new DiaryEntryRepository(connectionManager);

            diaryEntryRepository.InsertOne(new DiaryEntry { DateCreated = DateTime.Parse("2017/03/12 13:12:21").Ticks, Title = "Diary Entry 1" });
            diaryEntryRepository.InsertOne(new DiaryEntry { DateCreated = DateTime.Parse("2017/03/15 08:01:59").Ticks, Title = "Diary Entry 2" });
            diaryEntryRepository.InsertOne(new DiaryEntry { DateCreated = DateTime.Parse("2017/03/20 08:01:59").Ticks, Title = "Diary Entry 3" });

            var findCriteria = new DiaryEntryFindCriteria(DateTime.Parse("2017/03/14 13:12:21"), DateTime.Parse("2017/03/17 13:12:21"));


            IEnumerable<DiaryEntry> foundEntries = diaryEntryRepository.Find(findCriteria);

            Assert.That(foundEntries.Count(), Is.EqualTo(1));
            Assert.That(foundEntries.First().Title, Is.EqualTo("Diary Entry 2"));
        }
    }
}
