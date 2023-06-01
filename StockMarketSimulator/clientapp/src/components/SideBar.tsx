import {FaFire, FaPoo} from 'react-icons/fa';

const SideBar = () => {
    return (
        <div className='fixed top-0 left-0 h-screen w-16 m-0 flex flex-col shadow-lg
        bg-gray-100 text-gray-900  dark:bg-gray-900 dark:text-white  '>
            <SideBarIcon icon={<FaPoo size='20'/>}/>
            <SideBarIcon icon={<FaFire size='28'/>}/>
            <SideBarIcon icon={<FaPoo size='20'/>}/>
            <SideBarIcon icon={<FaFire size='28'/>}/>
            <SideBarIcon icon={<FaPoo size='20'/>}/>
        </div>
    )
};

// @ts-ignore
const SideBarIcon = ({icon, text = 'tooltip 🤘😎'}) => (
    <div className='sidebar-icon group'>
        {icon}

        <span className='sidebar-tooltip group-hover:scale-100'>
            {text}
        </span>
    </div>
);

export default SideBar;
