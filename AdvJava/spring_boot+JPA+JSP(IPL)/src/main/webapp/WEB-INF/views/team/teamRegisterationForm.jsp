<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<title>Insert title here</title>
</head>
<body>

<!-- String name, String abbreviation, String owner, int maxAge, double battingAvg,int wicketsTaken -->
 <form action="/spring_boot/Ipl/addTeam" method="post">
		<table style="background-color: lightgrey; margin: auto">
		<!-- int teamId, String name, String abbreviation, String owner, int maxAge, double battingAvg,int wicketsTaken -->
			
			<tr>
				<td>Team Name : </td>
				<td><input type="text" name="name" /></td>
			</tr>
			<tr>
				<td>Team Abbrevation : </td>
				<td><input type="text" name=abbreviation /></td>
			</tr>
			<tr>
				<td> Owner :</td>
				<td><input type="text" name="owner" /></td>
			</tr>
			<tr>
				<td>Max Age of Player :</td>
				<td><input type="number" name="maxAge" /></td>
			</tr>
			<tr>
				<td>Min Batting Average</td>
				<td><input type="number" value="0.00" step="0.01" name="battingAvg" /></td>
			</tr>
			<tr>
				<td>Min No Of Wickets Taken</td>
				<td><input type="number" name="wicketsTaken" /></td>
			</tr>
			<tr>
				<td><input type="submit" value="Add A Player" /></td>
			</tr>
		</table>
	</form>
</body>
</html>