Feature: Permissions of user


  Scenario Outline: Permission for internal message creation
    Given Admin logged in "<adminUserName>" "<adminPassword>"
    When Admin set permissions for user "<permissionName>" "<permissionValue>" "<user>"
    And User logs in "<userName>" "<password>"
    Then Visibilty of Internal Message button should be according to permissions  "<permissionValue>"

    Examples:
      | adminUserName | adminPassword | permissionName | permissionValue | user | userName | password | hiptest-uid |
      | AdminUserName | AdminPassword | Create Internal Message | true | arslan | UserName | Password |  |
      | AdminUserName | AdminPassword | Create Internal Message | false | arslan | UserName | Password |  |
