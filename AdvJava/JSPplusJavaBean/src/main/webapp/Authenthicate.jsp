<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html>
<html>
<head>
<meta charset="ISO-8859-1">
<title>Insert title here</title>
</head>
<%--create JB instance n add it under session --%>
<jsp:useBean id="user" class="beans.UserBean" scope="session"/>
<%-- passing clnt communication data to our bean --%>
<jsp:setProperty property="*" name="user"/>

<body>

<h4>${sessionScope.user.validateUser()}</h4>
</body>
</html>