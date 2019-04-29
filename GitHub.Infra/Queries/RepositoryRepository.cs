using System;
using System.Collections.Generic;
using System.Text;

namespace GitHub.Infra.Repositories
{
    public partial class RepositoryRepository
    {
        private const string QuerySelectById = @"SELECT *
                                                    FROM [dbo].[Repository]
                                                    WHERE Id = @Id";
        private const string QueryUpdate = @"
                                            MERGE INTO Repository AS Target  
                                            USING (VALUES (@Id, @NodeId, @Name, @FullName, @Private, @OwnerId, @HtmlUrl, @Description, @Fork, @Url))
                                                   AS Source (Id, NodeId, Name, FullName, Private, OwnerId, HtmlUrl, Description, Fork, Url )  
                                            ON Target.Id = Source.Id  
                                            WHEN MATCHED THEN  
                                            UPDATE SET Id=Source.Id, NodeId=Source.NodeId, Name=Source.Name, FullName=Source.FullName, Private=Source.Private, OwnerId=Source.OwnerId, HtmlUrl=Source.HtmlUrl, Description=Source.Description, Fork=Source.Fork, Url=Source.Url
                                            WHEN NOT MATCHED BY TARGET THEN  
                                            INSERT (Id, NodeId, Name, FullName, Private, OwnerId, HtmlUrl, Description, Fork, Url) VALUES (Id, NodeId, Name, FullName, Private, OwnerId, HtmlUrl, Description, Fork, Url)  
                                            OUTPUT $action;  ";
    }
}

//CREATE TABLE[dbo].[Sample]
//(
//   [Id] INT NOT NULL PRIMARY KEY IDENTITY,
//   [Description] VARCHAR(500) NOT NULL
//)

