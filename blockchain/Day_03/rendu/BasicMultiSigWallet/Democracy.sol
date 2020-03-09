pragma solidity^0.4.18;

contract Democracy {

  function Democracy() public {
    user_count = 1;
    users[msg.sender] = true;
    user_list.push(msg.sender);
  }

  mapping (address => bool) private users;
  uint256		    public user_count;
  address[]		    private user_list;

  struct Request {
    bool			instanced;
    mapping (address => bool)	votes;
    uint256			vote_count;
  }

  event RequestSignal (
      uint8	request_type,
      address	who
      );

  mapping (address => Request)   add_requests; 
  mapping (address => Request)   remove_requests;

  modifier memberOnly() {

    if (users[msg.sender] == false)
      revert();
    _;

  }

  function addMemberRequest(address _user) public memberOnly {

    if (add_requests[_user].instanced == false && users[_user] == false) {
      add_requests[_user].instanced = true;
      RequestSignal(0, _user);
    }

  }

  function votePendingAddMemberRequest(address _user, bool vote) public memberOnly {

    if (add_requests[_user].instanced == true) {
      if (add_requests[_user].votes[msg.sender] == false) {
	if (vote == true) {
	  add_requests[_user].votes[msg.sender] = true;
	  add_requests[_user].vote_count += 1;
	  RequestSignal(1, _user);
	} else {
	  revert();
	}
      } else {
	if (vote == false) {
	  add_requests[_user].votes[msg.sender] = false;
	  add_requests[_user].vote_count -= 1;
	  RequestSignal(2, _user);
	} else {
	  revert();
	}
      }
      if (add_requests[_user].vote_count == user_count) {
	users[_user] = true;
	user_count += 1;
	add_requests[_user].vote_count = 0;
	for (uint idx = 0; idx < user_list.length; ++idx) {
	  if (user_list[idx] != address(0)) {
	    if (add_requests[_user].votes[user_list[idx]] == true) {
	      add_requests[_user].votes[user_list[idx]] = false;
	    }
	  }
	}
	user_list.push(_user);
	RequestSignal(3, _user);
      }
    }

  }

  function removeMemberRequest(address _user) public memberOnly {

    if (remove_requests[_user].instanced == false && users[_user] == true) {
      remove_requests[_user].instanced = true;
      RequestSignal(4, _user);
    }

  }

  function removeMember(address _user, bool vote) public memberOnly {

    if (msg.sender != _user && remove_requests[_user].instanced == true) {
      if (remove_requests[_user].votes[msg.sender] == false) {
	if (vote == true) {
	  remove_requests[_user].votes[msg.sender] = true;
	  remove_requests[_user].vote_count += 1;
	  RequestSignal(5, _user);
	} else {
	  revert();
	}
      } else {
	if (vote == false) {
	  remove_requests[_user].votes[msg.sender] = false;
	  remove_requests[_user].vote_count -= 1;
	  RequestSignal(6, _user);
	} else {
	  revert();
	}
      }
      if (remove_requests[_user].vote_count >= user_count - 1) {
	users[_user] = false;
	user_count -= 1;
	remove_requests[_user].vote_count = 0;
	for (uint idx = 0; idx < user_list.length; ++idx) {
	  if (user_list[idx] == _user) {
	    user_list[idx] = address(0);
	    continue ;
	  }
	  if (user_list[idx] != address(0)) {
	    if (remove_requests[_user].votes[user_list[idx]] == true) {
	      remove_requests[_user].votes[user_list[idx]] = false;
	    }
	  }
	}
      }
    }
  }

}
