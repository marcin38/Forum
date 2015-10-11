GO
IF OBJECT_ID('GetUserNameAndDateFromPostId' , 'FN') IS NOT NULL
	DROP FUNCTION GetUserNameAndDateFromPostId;
GO



CREATE FUNCTION GetUserNameAndDateFromPostId(@PostId int)
RETURNS nvarchar(MAX)
AS
BEGIN
	DECLARE @name nvarchar(MAX);
	DECLARE @date nvarchar(MAX);

	SELECT @name = Users.Name, @date = convert(nvarchar(MAX), Posts.CreationDate , 0)
	from Posts 
	LEFT JOIN Users ON Users.Id = Posts.AuthorId
	WHERE Posts.Id = @PostId;

	return @date + ' by ' + @name;
END;



GO
IF OBJECT_ID('V_Categories', 'V') IS NOT NULL
	DROP VIEW V_Categories;

GO
CREATE VIEW V_Categories AS
SELECT 
Categories.Id, 
Categories.Name,
Categories.Description,
COUNT(DISTINCT Threads.Id) AS ThreadsNumber,
COUNT(Posts.Id) AS PostsNumber,
dbo.GetUserNameAndDateFromPostId(MAX(Posts.Id)) AS LastPost
FROM Categories 
LEFT JOIN Threads ON Categories.Id = Threads.CategoryId 
LEFT JOIN Posts ON Posts.ThreadId = Threads.Id 
GROUP BY Categories.Id, Categories.Name, Categories.Description

GO
IF OBJECT_ID('V_Threads', 'V') IS NOT NULL
	DROP VIEW V_Threads;

GO
CREATE VIEW V_Threads AS
SELECT 
Threads.Id,
Threads.Title,
Threads.CategoryId,
Posts.CreationDate AS WhenAddedLastPost, 
Users.Name AS WhoAddedLastPost,
(SELECT COUNT(1) FROM Posts WHERE ThreadId = Threads.Id) AS PostsNumber,
SUBSTRING(Posts.PostContent,1,100) + '...' AS LastPost
FROM Threads
LEFT JOIN Posts ON Threads.Id = Posts.ThreadId
LEFT JOIN Users ON Posts.AuthorId = Users.Id
Where Posts.Id = Threads.LastPost;

GO
