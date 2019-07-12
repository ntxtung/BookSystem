import React from 'react'

import { connect } from 'react-redux'
import { Redirect } from 'react-router';

class MainPage extends React.Component {
  render(){
    if (this.props.loggedInUser !== null) {
      return(
        <div>
          Hello {this.props.loggedInUser.lastname}
        </div>
      )
    } else {
      return (
        <Redirect push to="/auth" />
      )
    }
  }
}

const mapStateToProps = (state) => {
  return {
    loggedInUser: state.loggedInUser
  };
}

export default connect(mapStateToProps, {})(MainPage)