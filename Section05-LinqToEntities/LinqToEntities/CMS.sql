BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "Students" (
	"StudentId"	INTEGER NOT NULL UNIQUE,
	"FirstName"	TEXT,
	"LastName"	TEXT,
	"CourseId"	INTEGER,
	PRIMARY KEY("StudentId")
);
CREATE TABLE IF NOT EXISTS "Courses" (
	"CourseId"	INTEGER NOT NULL UNIQUE,
	"CourseName"	TEXT NOT NULL,
	PRIMARY KEY("CourseId")
);
INSERT INTO "Students" VALUES (101,'James','Smith',1);
INSERT INTO "Students" VALUES (102,'Robert','Smith',2);
INSERT INTO "Students" VALUES (103,'Maria','Garcia',3);
INSERT INTO "Students" VALUES (104,'David','Smith',1);
INSERT INTO "Students" VALUES (105,'James','Johnson',2);
INSERT INTO "Students" VALUES (106,'John','SevenLast',3);
INSERT INTO "Students" VALUES (107,'Maria','Rodriguez',1);
INSERT INTO "Students" VALUES (108,'Mary','Smith',2);

INSERT INTO "Courses" VALUES (1,'Computer Science');
INSERT INTO "Courses" VALUES (2,'Marketing');
INSERT INTO "Courses" VALUES (3,'Accounting');
COMMIT;