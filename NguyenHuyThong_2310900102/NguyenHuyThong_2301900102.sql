CREATE DATABASE NguyenHuyThong_231090012;
GO

USE NguyenHuyThong_231090012;
GO

CREATE TABLE NhtEmployee (
    nhtEmpID NVARCHAR(20) PRIMARY KEY,
    nhtEmpName NVARCHAR(100),    
    nhtEmpLevel NVARCHAR(20),
    nhtEmpStartDate DATE,
    nhtEmpStatus BIT
);


INSERT INTO NhtEmployee (nhtEmpId, nhtEmpName, nhtEmpLevel, nhtEmpStartDate, nhtEmpStatus)
VALUES
('E01', N'Nguyen Huy Thong', N'Sinh viên', '2023-09-01', 1),
('E02', N'Le Van A', N'Nhân viên', '2022-05-15', 1),
('E03', N'Tran Thi B', N'Quản lý', '2021-08-20', 0);
