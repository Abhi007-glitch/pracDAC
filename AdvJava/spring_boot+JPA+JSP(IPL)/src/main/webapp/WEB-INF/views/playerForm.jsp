<%@ page language="java" contentType="text/html; charset=UTF-8"
	pageEncoding="UTF-8"%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="UTF-8">
<title>Insert title here</title>
</head>



<!-- myTeam ,fn,ln,dob,avg(double),wickets -->
<body>
	<form action="/spring_boot/player/submit" method="post">
		<table style="background-color: lightgrey; margin: auto">
			<tr>
				<td>Select Team</td>
				<td><select name="myTeam">
						<c:forEach var="abbr"
							items="${requestScope.abbrList}">
							<option value="${abbr}">${abbr}</option>
						</c:forEach>
				</select></td>
			</tr>
			<tr>
				<td>Enter First Name</td>
				<td><input type="text" name="fn" /></td>
			</tr>
			<tr>
				<td>Enter Last Name</td>
				<td><input type="text" name="ln" /></td>
			</tr>
			<tr>
				<td>Select DoB</td>
				<td><input type="date" name="dob" /></td>
			</tr>
			<tr>
				<td>Enter Batting Average</td>
				<td><input type="number" value="0.00" step="0.01" name="avg" /></td>
			</tr> 
			<tr>
				<td>Enter No Of Wickets Taken</td>
				<td><input type="number" name="wickets" /></td>
			</tr>
			<tr>
				<td><input type="submit" value="Add A Player" /></td>
			</tr>
		</table>
	</form>
	
	<br>
	<br>
	
	<a href="team/register">Register a new Team</a>
	<a href="/spring_boot/player/getList"> Get ALL player Details</a>
	<%-- <h5>Teams : ${applicationScope.ipl.fetchAllTeams()}</h5> --%>
</body>


</html>