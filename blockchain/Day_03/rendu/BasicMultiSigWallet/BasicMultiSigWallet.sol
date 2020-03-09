pragma solidity^0.4.18;

import "./Democracy.sol";

contract BasicMultiSigWallet is Democracy {

  function BasicMultiSigWallet() Democracy() public {
  }

  event ReceivedFund(address from, uint256 amount);
  event SentFunds(address to, uint256 amount);

  function() public payable {
    if (msg.value != 0)
      ReceivedFund(msg.sender, msg.value);
    else
      revert();
  }

  struct SendRequest {
    uint256 amount;
    mapping (address => bool) votes_ok;
    mapping (address => bool) votes_ko;
    uint256 vote_ok_count;
    uint256 vote_ko_count;
    bool done;
    bool cancelled;
    address caller;
    address to;
  }

  SendRequest[]	  send_requests;

  function send(address _to, uint256 _amount) public memberOnly {
    if (this.balance >= _amount) {
      send_requests.push(SendRequest({amount: 0, vote_ok_count: 0, vote_ko_count: 0, done: false, cancelled: false, caller: msg.sender, to: _to}));
      send_requests[send_requests.length - 1].votes_ok[msg.sender] = true;
      send_requests[send_requests.length - 1].vote_ok_count += 1;
    } else {
      revert();
    }
    if (send_requests[send_requests.length - 1].vote_ok_count == Democracy.user_count) {
      if (send_requests[send_requests.length - 1].to.send(send_requests[send_requests.length - 1].amount) == false)
	{
	  send_requests[send_requests.length - 1].cancelled = true;
	} else {
	  SentFunds(_to, _amount);
	  send_requests[send_requests.length - 1].done = true;
	}
    }
  }

  function validate(uint256 _idx) public memberOnly {

    if (_idx < send_requests.length && send_requests[_idx].done == false && send_requests[_idx].cancelled == false) {
      if (send_requests[_idx].votes_ok[msg.sender] == false) {
	send_requests[_idx].votes_ok[msg.sender] = true; 
	send_requests[_idx].vote_ok_count += 1;
      }
      if (send_requests[_idx].votes_ko[msg.sender] == true) {
	send_requests[_idx].votes_ko[msg.sender] = false;
	send_requests[_idx].vote_ko_count -= 1;
      }
      if (send_requests[_idx].vote_ok_count == Democracy.user_count) {
	if (send_requests[_idx].to.send(send_requests[_idx].amount) == false) {
	  send_requests[_idx].cancelled = true;
	} else {
	  SentFunds(send_requests[_idx].to, send_requests[_idx].amount);
	  send_requests[_idx].done = true;
	}
      }

    } else {

      revert();

    }
  }

  function unvalidate(uint256 _idx) public memberOnly {

    if (_idx < send_requests.length && send_requests[_idx].done == false && send_requests[_idx].cancelled == false) {

      if (send_requests[_idx].votes_ko[msg.sender] == false) {
	send_requests[_idx].votes_ko[msg.sender] = true; 
	send_requests[_idx].vote_ko_count += 1;
      }
      if (send_requests[_idx].votes_ok[msg.sender] == true) {
	send_requests[_idx].votes_ok[msg.sender] = false;
	send_requests[_idx].vote_ok_count -= 1;
      }
      if (send_requests[_idx].vote_ko_count == Democracy.user_count) {
	send_requests[_idx].cancelled = true;
      }

    } else {

      revert();

    }
  }

  function cancel(uint256 _idx) public memberOnly {

    if (_idx < send_requests.length && send_requests[_idx].done == false && send_requests[_idx].cancelled == false && send_requests[_idx].caller == msg.sender) {

      send_requests[_idx].cancelled = true;

    } else {

      revert();

    }

  }

}


