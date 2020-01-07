# WCH学生选课系统

WCH = `We Can Hourse`

## 数据库表结构

### wch_Department 院系表

|列名|数据类型|约束|说明|
|--|--|--|--|
|DepID|tinyint|PRIMARY KEY IDENTITY(1,1)|院系编号|
|DepName|nvarchar(20)|not null|院系名称|

### wch_Class 班级表

|列名|数据类型|约束|说明|
|--|--|--|--|
|ClassID|int|PRIMARY KEY IDENTITY(1,1)|班级编号|
|ClassName|nvarchar(8)|not null|班级名称|
|DepID|tinyint|Foreign Key|院系编号|
|StuNum|int|null|学生数量|

### wch_Student 学生表

|列名|数据类型|约束|说明|
|--|--|--|--|
|StuID|nvarchar(20)|Primary Key|学生编号|
|StuName|nvarchar(8)|not null|学生姓名|
|Gender|bit|not null|性别|
|ClassID|int|Foreign Key|班级号|
|DepID|tinyint|Foreign Key|院系号|
|StuAge|tinyint| >0|年龄|
|Tel|nvarchar(20)|null|电话|
|Grade|date|less then now|年级|
|Address|nvarchar(50)|null|地址|

### wch_Teacher 教师表

|列名|数据类型|约束|说明|
|--|--|--|--|
|TeaID|nvarchar(20)|Primary Key|教师编号|
|TeaName|nvarchar(8)|not null|教师姓名|
|Gender|bit|not null|性别|
|DepID|tinyint|Foreign Key|院系号|
|TeaAge|tinyint| >0|年龄|
|Tel|nvarchar(20)|null|电话|
|Address|nvarchar(50)|null|地址|

### wch_Schedule 上课时间安排表

|列名|数据类型|约束|说明|
|--|--|--|--|
|ScheduleID|int|PRIMARY KEY IDENTITY(1,1)|上课时间安排编号|
|TimeSpan|nvarchar(20)|起止时间|上课时间|

### wch_Theatre 教室表

|列名|数据类型|约束|说明|
|--|--|--|--|
|TheatreID|int|PRIMARY KEY IDENTITY(1,1)|教室编号|
|SeatCapacity|int|not null|座位容量|
|Site|nvarchar(20)|not null|地点|

### wch_Term 学期表

|列名|数据类型|约束|说明|
|--|--|--|--|
|TermID|int|PRIMARY KEY IDENTITY(1,1)|学期编号|
|TermName|nvarchar(30)|not null|显示名称|
|StartTime|date|not null|学期开始时间|
|EndTime|date|check > StartTime|学期结束时间|
|StartChoice|date|not null|开始选课时间|
|EndChoice|date|check > StartChoice|结束选课时间|

### wch_Course 课程表

|列名|数据类型|约束|说明|
|--|--|--|--|
|CourseID|nvarchar(20)|Primary Key|课程号|
|CourseName|nvarchar(30)|not null|课程名称|
|Period|int|not null|学时|
|Credit|int|not null|学分|
|DepID|tinyint|foreign key|所属院系|

### wch_TimeTable 排课表

|列名|数据类型|约束|说明|
|--|--|--|--|
|TimeID|int|PRIMARY KEY IDENTITY(1,1)|排课编号|
|CourseID|nvarchar(20)|foreign key|课程号|
|TeaID|nvarchar(20)|foreign key|教师编号|
|StuNum|int|小于容量范围|已选学生数量|
|Capacity|int|not null|容量|
|AllowView|bit|default 0|可以选课|

### wch_TimeTableDetail 排课时间详情表

|列名|数据类型|约束|说明|
|--|--|--|--|
|TimeID|int|foreign key|排课编号|
|TermID|int|foreign key|学期编号|
|Day|tinyint|1-7|星期|
|ScheduleID|int|foreign key|上课时间安排编号|
|TheatreID|int|foreign key|教室编号|

### wch_CourseSelection 选课表

|列名|数据类型|约束|说明|
|--|--|--|--|
|StuID|nvarchar(20)|Foreign Key|学号|
|TimeID|int|null|排课编号|
|Mark|float|null|分数|

### wch_Login 登录表

|列名|数据类型|约束|说明|
|--|--|--|--|
|UserID|int|PRIMARY KEY|用户名|
|Passwd|varchar(50)|not null|加密密码|
|Identity|int|not null|用户标识1(Admin),2(Tea),3(Stu)|
|Nickname|nvarchar(20)|null|昵称|
|PhotoPath|varchar(100)|null|头像地址|
|AllowLogin|bit|not null|允许登录|