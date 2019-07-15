import React from 'react'

import { connect } from 'react-redux'

class FundPage extends React.Component {
  render(){
    return(
      <div>
        Hello Fund
      </div>
    )
  }
}

const mapStateToProps = (state) => {
  return {
    loggedInUser: state.loggedInUser
  };
}

export default connect(mapStateToProps, {})(FundPage)