Feature: Message actions

Scenario Outline: message - Add attachement to message - 1 file - personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"	
	Examples:
		| adminUserName | adminPassword | level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType |
		| AdminUserName | AdminPassword | ديوان الوزارة | Users        | user_hq | Message with attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 1                    | 1.jpg                    |

Scenario Outline: message - Add attachement to message - 1 file - department mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an departmental internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then mail should appear in department message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Examples:
		| adminUserName | adminPassword | level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType | dept                      |
		| AdminUserName | AdminPassword | ديوان الوزارة | Users        | user_hq | Message with attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 1                    | 1.jpg                  | internalDepartmentSameDep |

Scenario Outline: Message- Add attachement (multiple files)- personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"	
	Examples:
		| adminUserName | adminPassword | level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType |
		| AdminUserName | AdminPassword | ديوان الوزارة | Users        | user_hq | Message with attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 100                   | 1.jpg                    |

Scenario Outline: Message- Add attachement (multiple files)- Department mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an departmental internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then mail should appear in department message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Examples:
		| adminUserName | adminPassword | level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType | dept                      |
		| AdminUserName | AdminPassword | ديوان الوزارة | Users        | user_hq | Message with attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 100                    | 1.jpg                  | internalDepartmentSameDep |

Scenario Outline: Message- Add attachement (multiple file types)- personal mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"
	Then mail should appear in my message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>"	
	Examples:
		| adminUserName | adminPassword | level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType |
		| AdminUserName | AdminPassword | ديوان الوزارة | Users        | user_hq | Message with attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 3                   | 1.png,1.mp3,1.avi |

Scenario Outline: Message- Add attachement (multiple file types)- department mail
	Given Admin logged in "<adminUserName>" "<adminPassword>"
	When user sends an departmental internal message with attachment to "<level>" "<receiverType>" "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Then mail should appear in department message out box "<to>" "<subject>" "<content>" "<multipleAttachementNo>" "<multipleAttachmentType>" "<dept>"
	Examples:
		| adminUserName | adminPassword | level         | receiverType | to      | subject                      | content                      | userName           | password                   | multipleAttachementNo | multipleAttachmentType		  | dept                      |
		| AdminUserName | AdminPassword | ديوان الوزارة | Users        | user_hq | Message with attachement 111 | Message with attachement 111 | UserSameDepartment | PasswordUserSameDepartment | 3                  | 1.png,1.mp3,1.avi | internalDepartmentSameDep |
