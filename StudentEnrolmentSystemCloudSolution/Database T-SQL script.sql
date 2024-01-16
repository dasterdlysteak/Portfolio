-- Create the Courses table
CREATE TABLE Courses (
    courseID VARCHAR(15) PRIMARY KEY,
    courseName VARCHAR(45) NOT NULL,
    cost DECIMAL(18, 2) NULL,
    allottedTime DATETIME NULL
);

-- Create the Students table
CREATE TABLE Students (
    studentID VARCHAR(12) PRIMARY KEY,
    studentName VARCHAR(45) NOT NULL,
    dateEnrolled DATE NULL
);

-- Create the Grades table with foreign keys
CREATE TABLE Grades (
    studentID VARCHAR(12) FOREIGN KEY REFERENCES Students(studentID),
    courseID VARCHAR(15) FOREIGN KEY REFERENCES Courses(courseID),
    grade VARCHAR(10) NULL,
    PRIMARY KEY (studentID, courseID)
);