pragma solidity^0.4.18;

contract UserRegistry {

  address public  owner;

  function UserRegistry() public {

    owner = msg.sender;

  }

  modifier ownerOnly() {

    if (msg.sender != owner)
      revert();
    _;

  }

  function kill() public ownerOnly {

    selfdestruct(owner);

  }

  mapping (address => bool) private users;

  function addUser(address _user) public ownerOnly {

    if (users[_user] == false) {
      users[_user] = true;
    }

  }

  function removeUser(address _user) public ownerOnly {

    if (users[_user]) {
      users[_user] = false;
    }

  }

  function isUser(address _user) public constant returns (bool) {

    return (users[_user] || _user == owner);

  }

  function isOwner(address _owner) public constant returns (bool) {

    return (_owner == owner);

  }

}
