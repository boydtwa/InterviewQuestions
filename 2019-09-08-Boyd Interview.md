# 2019-09-8 Interview questions of Boyd Taylor
## Interview 1 Database focus
given the following table (called foo)

| Event  | UserId |
| ------ | ------ |
| Launch | uid1   |
| Checked | uid1  |
| Launch | uid2  |
| Submit | uid1 |
| Checked | uid3 |

Proper user sequence is Launch, Checked, Submit

### Find all users who successfully completed the sequence.
<pre>
select count(*), user
from  foo
    where Event in ('Launch','Checked',Submit) 
    and count(*) = 3
group by user
</pre>
### Find all users who only did the launch event 
<pre>
select count(*), user
from  foo
    where Event in ('Launch','Checked',Submit) 
    and count(*) = 1 
    and Event = 'Launch'
group by user
</pre>
### Find users with invalid sequence

<pre>

select a.user, b.user
from foo a
left outer join (
select count(*), user
    from  foo
    where Event in ('Launch','Checked',Submit) 
    and count(*) = 3
    group by user

)b on b.user = a.user
where b.user is null;

</pre>



## Interview 2 Code Focus (w/Database)

### Given a file path: C:\abc\def\..\ghi\.\jkl identifiy the path without dot notations.

Can be done with a regular express match
replace all "\" with "/"

pattern: <pre>(\/([^[\\\\\\:\\\*\\\?\\"\\<\\>]*)\\/\\.\\.\\/)|(\/\.\/)
</pre>
The Not group ([^[\\\\\\:\\\*\\\?\\"\\<\\>]*) is the set of  illeagl charcaters in a file name
<br>
replace with: <pre>/</pre>

<code>

</code>

### If file path was in a database what how would you deal with it?
<pre>I would strip the dot notations from the file path prior to inserting it into the database</pre>

### Write code to produce a string that is the reverse the file path (lkj\.\ihg\..\fed\cba\:C)

#### Logic 
1) convert string to char array
2) create a stack object
3) loop through array and push values to stack
4) Create string builder and pop values from stack to string builder
5) Get string of string builder.

```c#

string dirPath = "c:\\abc\\def\\..\\ghi\\.\\jkl";
char[] fwdArray = dir.Path.ToCharArray();
Stack charStack = new Stack();
foreach (var charVal in fwdArray){
    charStack.Push(charVal);
}
StringBuilder revBuild = new StringBuilder();
while(charStack.Count > 0){
    builder.Append(charStack.Pop());
}
string revDirPath = builder.ToString();

```


